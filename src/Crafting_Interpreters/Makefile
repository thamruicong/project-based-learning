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
			lox/AstPrinter.java \
			tool/GenerateAst.java \

default: classes

classes: $(CLASSES:.java=.class)

clean:
	find . -name "*.class" -type f -delete
	
run:
	java lox/Lox

ast:
	java tool/GenerateAst lox
