CC      = gcc
CFLAGS  = -std=c99 -ggdb3 -Wall -Wextra -Wwrite-strings
LDLIBS  = -lraylib
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
