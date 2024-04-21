package lox;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class Lox {
    /**
     * A flag to indicate if an error occurred during the execution of the program.
     */
    private static boolean hadError = false;
    
    /**
     * The exit code to indicate a usage error.
     */
    private static final int EX_USAGE = 64;

    /**
     * The exit code to indicate a data error.
     */
    private static final int EX_DATAERR = 65;


    /**
     * Private constructor to prevent instantiation of this class.
     */
    private Lox() { }

    /**
     * The entry point of the program.
     * 
     * @param args The command line arguments.
     * @throws IOException If an I/O error occurs.
     */
    public static void main(String[] args) throws IOException {
        if (args.length > 1) {
            System.out.println("Usage: jlox [script]");
            System.exit(EX_USAGE); 
        } else if (args.length == 1) {
            runFile(args[0]);
        } else {
            runPrompt();
        }
    }

    private static void runFile(String path) throws IOException {
        byte[] bytes = Files.readAllBytes(Paths.get(path));
        run(new String(bytes, Charset.defaultCharset()));
    
        // Indicate an error in the exit code.
        if (hadError) System.exit(EX_DATAERR);
    }

    private static void runPrompt() throws IOException {
        InputStreamReader input = new InputStreamReader(System.in);
        BufferedReader reader = new BufferedReader(input);
        
        for (;;) {
            System.out.print("> ");
            String line = reader.readLine();
            if (line == null) break;
            run(line);
            hadError = false;
        }
    }

    private static void run(String source) {
        Scanner scanner = new Scanner(source);
        List<Token> tokens = scanner.scanTokens();

        // For now, just print the tokens.
        for (Token token : tokens) {
            System.out.println(token);
        }
    }

    /**
     * Report an error.
     * 
     * @param line The line number where the error occurred.
     * @param message The error message.
     */
    public static void error(int line, String message) {
        report(line, "", message);
    }

    private static void report(int line, String where, String message) {
        String msg = String.format("[line %d] Error%s: %s",
            line, where, message);
        System.err.println(msg);
        hadError = true;
    }
}
