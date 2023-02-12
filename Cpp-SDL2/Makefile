CC      = g++
CFLAGS  = -std=c++20 -ggdb3 -Wall -Wextra -Wwrite-strings
LDLIBS  = -lSDL2 -lSDL2_image -lSDL2_ttf -lSDL2_mixer -lfmt
TARGET  = yellow-snow

SRCS    = $(wildcard *.cpp)
OBJS    = $(SRCS:.cpp=.o)

.PHONY: all
all: $(TARGET)

%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $(LDLIBS) $^ -o $@

.PHONY: clean
clean:
	$(RM) $(OBJS) $(TARGET)
