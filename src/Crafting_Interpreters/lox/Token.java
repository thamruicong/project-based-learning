package lox;

class Token {
    /**
     * The type of the token.
     */
    public final TokenType type;

    /**
     * The lexeme of the token.
     */
    public final String lexeme;

    /**
     * The literal value of the token.
     */
    public final Object literal;

    /**
     * The line number in the source code where the token appears.
     */
    public final int line; 


    /**
     * Create a new token.
     * 
     * @param type The type of the token.
     * @param lexeme The lexeme of the token.
     * @param literal The literal value of the token.
     * @param line The line number in the source code where the token appears.
     */
    Token(TokenType type, String lexeme, Object literal, int line) {
        this.type = type;
        this.lexeme = lexeme;
        this.literal = literal;
        this.line = line;
    }

    /**
     * Return a string representation of the token.
     * 
     * @return A string representation of the token.
     */
    @Override
    public String toString() {
        return type + " " + lexeme + " " + literal;
    }
}
