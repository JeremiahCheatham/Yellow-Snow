CC  = gcc
CFLAGS = -std=c99 -ggdb3 -Wall -Wextra -Wwrite-strings
LDLIBS = -lSDL2 -lm -lSDL2_image -lSDL2_ttf -lSDL2_mixer
TARGET = yellow-snow

SRCS=$(wildcard *.c)
OBJS=$(SRCS:.c=.o)

.PHONY: all
all: $(TARGET)

%.o : %.c
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $(LDLIBS) $^ -o $@

.PHONY: clean
clean:
	$(RM) $(OBJS) $(TARGET)