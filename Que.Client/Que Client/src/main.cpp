#include <fstream>
#include <iostream>
#include <SFML/Graphics.hpp>
#include "Defines.h"
#include "Screen.h"
#include "Screen_Loading.h"
#include "Screen_Main.h"
#include "Screen_Browse.h"
#include "Screen_Error.h"
#include "QueException.h"
#include "Config.h"

#include <sys/types.h>		// For u_char

#ifdef __APPLE__
#include "dns_sd.h"
#else
#include <direct.h>
#endif

void browseForServer();

int stopNow = 0;
#ifdef __APPLE__
static void DNSSD_API resolve_reply(DNSServiceRef sdref, const DNSServiceFlags flags, uint32_t ifIndex, DNSServiceErrorType errorCode,
                                    const char *fullname, const char *hosttarget, uint16_t opaqueport, uint16_t txtLen, const unsigned char *txtRecord, void *context)
{
	union { uint16_t s; u_char b[2]; } port = { opaqueport };
	uint16_t PortAsNumber = ((uint16_t)port.b[0]) << 8 | port.b[1];
    
	(void)sdref;        // Unused
	(void)ifIndex;      // Unused
	(void)context;      // Unused
    
	if (errorCode)
		printf("Error code %d\n", errorCode);
	else
    {
        std::string host = hosttarget;
        Parser::SetServer(host.substr(0, host.length() - 1), PortAsNumber);
		printf("Found %s on2 %s:%u\n", fullname, hosttarget, PortAsNumber);
    }
    stopNow = 1;
}
#endif
void browseForServer()
{
#ifdef __APPLE__
    std::cout << "Searching for server..." << std::endl;
    uint32_t opinterface = kDNSServiceInterfaceIndexAny;
    DNSServiceRef client    = NULL;
    DNSServiceRef client_pa    = NULL;
    int timeOut = 100000000;
    
    DNSServiceResolve(&client, 0, opinterface, "Que Jukebox", "_que._tcp", "local", resolve_reply, NULL);
    
    int dns_sd_fd  = client    ? DNSServiceRefSockFD(client   ) : -1;
	int dns_sd_fd2 = client_pa ? DNSServiceRefSockFD(client_pa) : -1;
	int nfds = dns_sd_fd + 1;
	fd_set readfds;
	struct timeval tv;
	int result;
	
	if (dns_sd_fd2 > dns_sd_fd) nfds = dns_sd_fd2 + 1;
    
	while (!stopNow)
    {
		// 1. Set up the fd_set as usual here.
		// This example client has no file descriptors of its own,
		// but a real application would call FD_SET to add them to the set here
		FD_ZERO(&readfds);
        
		// 2. Add the fd for our client(s) to the fd_set
		if (client   ) FD_SET(dns_sd_fd , &readfds);
		if (client_pa) FD_SET(dns_sd_fd2, &readfds);
        
		// 3. Set up the timeout.
		tv.tv_sec  = timeOut;
		tv.tv_usec = 0;
        
		result = select(nfds, &readfds, (fd_set*)NULL, (fd_set*)NULL, &tv);
		if (result > 0)
        {
			DNSServiceErrorType err = kDNSServiceErr_NoError;
			if      (client    && FD_ISSET(dns_sd_fd , &readfds)) err = DNSServiceProcessResult(client   );
			else if (client_pa && FD_ISSET(dns_sd_fd2, &readfds)) err = DNSServiceProcessResult(client_pa);
			if (err) { fprintf(stderr, "DNSServiceProcessResult returned %d\n", err); stopNow = 1; }
        }
		else if (result == 0)
        {
		//	myTimerCallBack();
		}
        else
        {
			//printf("select() returned %d errno %d %s\n", result, errno, strerror(errno));
			//if (errno != 4) stopNow = 1;
        }
    }
#endif
}

//#define DEBUG_CACHE
//#define FULLSCREEN	1
//#define HIDE_CURSOR	0

Screen_Browse screenBrowse;

void LoadPlaylists();
void LoadPlaylists()
{
    screenBrowse.LoadPlaylists();
}

int main(int argc, char* argv[], char* envp[])
{
	Config config("client.cfg", envp);

	bool fullscreen = config.pBool("fullscreen");
	bool hideCursor = config.pBool("hideCursor");

	// Redirect stdout and stderr to files
	freopen("log.txt", "w+", stdout);
	freopen("log_errors.txt", "w+", stderr);

	// Write time to log
	time_t t = time(0);
    struct tm * now = localtime( & t );
    std::cout << "---- Q Client started " << (now->tm_year + 1900) << '-' 
         << (now->tm_mon + 1) << '-'
         <<  now->tm_mday
         << "----" << std::endl;

	// Get working dir
    char *path = NULL;
    size_t size;
    path = getcwd(path, size);
    printf("Working dir: %s\n", path);
	
	std::cout << "Hide cursor: " << fullscreen << std::endl;
	std::cout << "Fullscreen: " << hideCursor << std::endl;
    
#ifdef __APPLE__
    browseForServer();
#else
    Parser::SetServer(config.pString("server"), 7879); // Jukebox server
	//Parser::SetServer("127.0.0.1", 7879); // Lokal
#endif

    // Applications variables
    std::vector<Screen*> screens;
    int screen = 0;
    
    // Window creation
    sf::ContextSettings Settings;
#ifndef __APPLE__
	Settings.antialiasingLevel = 2; // Does this work on windows?
#endif
	sf::RenderWindow App;

	if (fullscreen)
	{
		App.create(sf::VideoMode(1920, 1080, 32), "Que", sf::Style::Fullscreen, Settings);
	}
	else
	{	
		App.create(sf::VideoMode(1920, 1080, 32), "Que", sf::Style::Default, Settings);
	}

	if (hideCursor)
	{
		App.setMouseCursorVisible(false);
	}

    // Screens preparations
    Screen_Loading screenLoading;
    screens.push_back(&screenLoading);
    
    Screen_Main screenMain;
    screens.push_back(&screenMain);
    
    screens.push_back(&screenBrowse);
    
    screenLoading.SetScreenBrowse(&screenBrowse);
	sf::Thread Thread(&LoadPlaylists);
	Thread.launch();
    
    Screen_Error screenError;
    screens.push_back(&screenError);
    
	App.setFramerateLimit(100); // Cap to 100 FPS
    
    // Main loop
    while (screen >= 0)
    {
        try
        {
            screen = screens[screen]->Run(App);
        }
        catch (QueException e)
        {
			std::cout << "Exception: " << e.what();
            screen = 3; // Show error screen
        }
        catch (...)
        {
            printf("Catched random exception\n");
        }
    }
    
    return 0;
}
