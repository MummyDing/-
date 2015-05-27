#ifndef DLL_EXPORT
#define DECLDIR __declspec(dllimport)
#else
#define DECLDIR __declspec(dllexport)
#endif