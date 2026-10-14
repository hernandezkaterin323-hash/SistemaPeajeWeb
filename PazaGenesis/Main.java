import java.util.Scanner;
import java.util.Random;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.println("=================================");
        System.out.println("       PLAZA GÉNESIS");
        System.out.println("      SISTEMA DE TICKETS");
        System.out.println("=================================");

        System.out.print("Ingrese la placa: ");
        String placa = scanner.nextLine().toUpperCase();

        System.out.println("\nSeleccione el vehículo:");
        System.out.println("1. Automóvil - L 20.00");
        System.out.println("2. Motocicleta - L 10.00");
        System.out.println("3. Pickup - L 30.00");
        System.out.println("4. Camión - L 50.00");

        System.out.print("Opción: ");

        int opcion = scanner.nextInt();

        String tipoVehiculo;
        double tarifa;

        switch (opcion) {

            case 1:
                tipoVehiculo = "Automóvil";
                tarifa = 20.00;
                break;

            case 2:
                tipoVehiculo = "Motocicleta";
                tarifa = 10.00;
                break;

            case 3:
                tipoVehiculo = "Pickup";
                tarifa = 30.00;
                break;

            case 4:
                tipoVehiculo = "Camión";
                tarifa = 50.00;
                break;

            default:
                System.out.println("Opción inválida.");
                scanner.close();
                return;
        }

        int numero = random.nextInt(900000) + 100000;

        String codigo = "PG-" + numero;

        System.out.println("\n=================================");
        System.out.println("        TICKET GENERADO");
        System.out.println("=================================");
        System.out.println("Código: " + codigo);
        System.out.println("Placa: " + placa);
        System.out.println("Vehículo: " + tipoVehiculo);
        System.out.printf("Tarifa: L %.2f%n", tarifa);
        System.out.println("Plaza: Plaza Génesis");
        System.out.println("Ubicación: Sonaguera, Colón");
        System.out.println("=================================");

        scanner.close();
    }
}