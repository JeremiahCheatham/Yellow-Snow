#ifndef EXIT_H
#define EXIT_H

#include "common.h"
#include "text.h"

// Release memory and null pointers before exiting.
void memory_release_exit(struct Game *game, struct Text *text);

#endif