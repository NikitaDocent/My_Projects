import java.util.Arrays;

public class Demo {
    public static void main(String[] args) {
//        Variable xVar = new Variable("x");
//        Parser parser = new Parser(Parser.STANDARD_FUNCTIONS);
//        parser.add(xVar);
//
//        Expression expression = parser.parse("(sqrt(x^2 - 9))/e^(0.1*x)");
//        ExpressionInput input = new ExpressionInput("(sqrt(x^2 - 9))/e^(0.1*x)",parser);
//        System.out.println(expression.derivative(xVar));

        //TODO PART 1
        //System.out.println(mod2lab1.Function.f(5));
        System.out.println(Integral.solveByTrapeze(3,8) + " метод трапецій");

        System.out.println(Integral.solveByRectangle(8.0,3.0 ) + " метод прямокутників");

        System.out.println(Integral.solveByParabola(3.0,8.0) + " метод парабол(Сімпсона)");

    }
}
