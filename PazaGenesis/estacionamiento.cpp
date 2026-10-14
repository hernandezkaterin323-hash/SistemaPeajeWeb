#include <iostream>
#include <string>
#include <cstdlib>
#include <ctime>

using namespace std;

int main() {

    string placa;
    int opcion;

    cout << "=================================" << endl;
    cout << "        PLAZA GENESIS" << endl;
    cout << "       SISTEMA DE TICKETS" << endl;
    cout << "=================================" << endl;

    cout << "Ingrese la placa: ";
    cin >> placa;

    cout << endl;

    cout << "Seleccione el vehiculo:" << endl;
    cout << "1. Automovil - L 20.00" << endl;
    cout << "2. Motocicleta - L 10.00" << endl;
    cout << "3. Pickup - L 30.00" << endl;
    cout << "4. Camion - L 50.00" << endl;

    cout << "Opcion: ";
    cin >> opcion;

    string tipoVehiculo;
    double tarifa;

    switch (opcion) {

        case 1:
            tipoVehiculo = "Automovil";
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
            tipoVehiculo = "Camion";
            tarifa = 50.00;
            break;

        default:
            cout << "Opcion invalida." << endl;
            return 0;
    }

    srand(time(0));

    int numero = 100000 + rand() % 900000;

    string codigo = "PG-" + to_string(numero);

    cout << endl;
    cout << "=================================" << endl;
    cout << "         TICKET GENERADO" << endl;
    cout << "=================================" << endl;

    cout << "Codigo: " << codigo << endl;
    cout << "Placa: " << placa << endl;
    cout << "Vehiculo: " << tipoVehiculo << endl;
    cout << "Tarifa: L " << tarifa << endl;
    cout << "Plaza: Plaza Genesis" << endl;
    cout << "Ubicacion: Sonaguera, Colon" << endl;

    cout << "=================================" << endl;

    return 0;
}