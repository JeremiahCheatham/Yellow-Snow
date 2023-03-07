CC      = gcc
CFLAGS  = `sdl2-config --cflags` -std=c99 -ggdb3 -Wall -Wextra -Wwrite-strings
LDLIBS  = `pkg-config --libs sdl2 SDL2_image SDL2_ttf SDL2_mixer`
TARGET  = yellow-snow

SRCS    = $(wildcard *.c)
OBJS    = $(SRCS:.c=.o)

.PHONY: all
all: $(TARGET)

%.o: %.cc
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $(LDLIBS) $^ -o $@

.PHONY: clean
clean:
	$(RM) $(OBJS) $(TARGET)
