import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 50,
    duration: '30s',
};

export default function () {

    let productsAsync = http.get('http://localhost:5145/api/productsasync');
    check(productsAsync, {
        'ProductsAsync OK': (r) => r.status === 200,
    });

    let productsSync = http.get('http://localhost:5145/api/productssync');
    check(productsSync, {
        'ProductsSync OK': (r) => r.status === 200,
    });


    let clientsAsync = http.get('http://localhost:5145/api/Client');
    check(clientsAsync, {
        'Client OK': (r) => r.status === 200,
    });


    let clientsSync = http.get('http://localhost:5145/api/ClientSync');
    check(clientsSync, {
        'ClientSync OK': (r) => r.status === 200,
    });


    let cartAsync = http.get('http://localhost:5145/api/CartAsync/1');
    check(cartAsync, {
        'CartAsync OK': (r) => r.status === 200 || r.status === 404,
    });

    let cartSync = http.get('http://localhost:5145/api/Cart/1');
    check(cartSync, {
        'CartSync OK': (r) => r.status === 200 || r.status === 404,
    });

    sleep(1);
}