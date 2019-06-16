public class Integral {
    private static double f(double x){
        return Math.sqrt(1 - 0.25*Math.pow(Math.sin(x),2));
    }
    public static double solveByTrapeze(int A, int B){
        double result;
        double x = A;
        double h = 0.2;
        double n = (B-A)/h;
        result = (f(A) + f(B))/2.0;

        for(int i =1; i <=n-1;i++){
            x+=h;
            result+=f(x);
        }
        result=h*result;
        return result;
    }

    public static double solveByRectangle(double a, double b){
        double step = 0.2;
            double ans = 0.0;
            for(double x = b + step; x<=a; x+=step){
                ans += f(x-step*0.5)*step;
            }
            return ans;
    }
    public static double solveByParabola(double a, double b){
         double h = 0.2;
         double I,
                I2=0.0,
                I4;
        I4 = f(a+h);
        double m = (b-a)/h;
        for(int k=2;k < m;k+=2){
            I4 += f(a+(k+1)*h);
            I2 += f(a+k*h);
        }
        I = f(a) + f(b) + 4 * I4 + 2 * I2;
        I *= h/3.0;
        return I;
    }
}
