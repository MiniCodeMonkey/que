#ifndef __QUEEXCEPTION_H__
#define __QUEEXCEPTION_H__

#include <stdexcept>

class QueException : public std::runtime_error
{
public:
	QueException(const std::string& errorMessage) : std::runtime_error(errorMessage) { }
};

#endif