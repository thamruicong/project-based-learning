JFLAGS = -g
JC = javac

.SUFFIXES: .java .class

.java.class:
	$(JC) $(JFLAGS) $*.java

# This uses the line continuation character (\) for readability.
# Compile .java files in dependency order.
CLASSES = \
		  lox/TokenType.java \
		  lox/Token.java \
		  lox/Scanner.java \
		  lox/Lox.java \

default: classes

classes: $(CLASSES:.java=.class)

clean:
	$(RM) lox/*.class
	
run:
	java lox/Lox