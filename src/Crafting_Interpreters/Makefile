JFLAGS = -g
JC = javac

.SUFFIXES: .java .class

.java.class:
	$(JC) $(JFLAGS) $*.java

# This uses the line continuation character (\) for readability.
# Compile .java files in dependency order.
BASE_CLASSES = \
		  lox/TokenType.java \
		  lox/Token.java \
		  lox/Scanner.java \
		  lox/Lox.java \
			tool/GenerateAst.java

# These classes depend on generated classes.
POST_CLASSES = \
			lox/AstPrinter.java

# All classes
CLASSES = $(BASE_CLASSES) $(POST_CLASSES)

default: build

build: compile_base generate_ast compile_post

compile_base: $(BASE_CLASSES:.java=.class)

generate_ast: compile_base
	java tool/GenerateAst lox

compile_post: $(POST_CLASSES:.java=.class)

clean:
	find . -name "*.class" -type f -delete
	$(RM) lox/Expr.java
	
run: build
	java lox/Lox
