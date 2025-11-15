#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <algorithm>
#include <Windows.h>
using namespace std;

struct Details {
    string type;
    string firm;
    string model;
    union {
        int warranty;
        float discount;
    } extra;
};

struct Product {
    string name;
    double price;
    Details info;
    void Print() {
        cout << name << " " << price << " "
        << info.type << " " << info.model << '\n';
    }
};

class Store {
    vector<Product*> products;
    string filename;
public:
    Store(string file) : filename(file) { load(); }
    ~Store() {
        for (size_t i = 0; i < products.size(); i++)
            delete products[i];
    }

    void load() {
        ifstream f(filename);
        if (!f) return;
        Product* p;
        while (true) {
            p = new Product;
            if (!(f >> p->name >> p->price >> p->info.type >> p->info.firm >> p->info.model >> p->info.extra.warranty)) {
                delete p;
                break;
            }
            products.push_back(p);
        }
        f.close();
    }

    void save() {
        ofstream f(filename);
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            f << p->name << ' ' << p->price << ' ' << p->info.type << ' '
                << p->info.firm << ' ' << p->info.model << ' ' << p->info.extra.warranty << '\n';
        }
        f.close();
    }

    void add() {
        Product* p = new Product;
        cout << "Назва: "; cin >> p->name;
        cout << "Ціна: "; cin >> p->price;
        if (p->price <= 0) { delete p; return; }
        cout << "Тип: "; cin >> p->info.type;
        cout << "Фірма: "; cin >> p->info.firm;
        cout << "Модель: "; cin >> p->info.model;
        cout << "Гарантія(міс): "; cin >> p->info.extra.warranty;
        products.push_back(p);
        //save(); поправити
    }

    void showAll() {
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            cout << p->name << " " << p->price << "грн "
                << p->info.type << " " << p->info.firm << " "
                << p->info.model << " гарантія:" << p->info.extra.warranty << "міс\n";
            //зробити гарне виведення
        }
    }

    void del(const string& name) {
        for (size_t i = 0; i < products.size();) {
            if (products[i]->name == name) {
                delete products[i];
                products.erase(products.begin() + i);
            }
            else i++;
            //fix
        }
        save();
    }

    void edit(const string& name) {
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            if (p->name == name) {
                cout << "Нова ціна: "; cin >> p->price;
                if (p->price <= 0) p->price = 1;
            }
        }
        save();
    }

    void sortByName() {
        sort(products.begin(), products.end(),
            [](Product* a, Product* b) { return a->name < b->name; });
    }

    void sortByPrice() {
        sort(products.begin(), products.end(),
            [](Product* a, Product* b) { return a->price < b->price; });
    }

    void searchFirm(const string& firm) {
        for (size_t i = 0; i < products.size(); i++) {
            if (products[i]->info.firm == firm){
                products[i]->Print();
            }
        }
        //fix
    }

    void selectTypePrice(const string& type, double x, double y) {
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            if (p->info.type == type && p->price >= x && p->price <= y)
                cout << p->name << " " << p->price << '\n';
        }
    }

    void averageType(const string& type) {
        double sum = 0;
        int count = 0;
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            if (p->info.type == type) {
                sum += p->price;
                count++;
            }
        }
        if (count)
            cout << "Середня ціна: " << sum / count << '\n';
    }

    void changePriceType(const string& type, double percent) {
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            if (p->info.type == type)
                p->price += p->price * percent / 100.0;
        }
        save();
    }

    void reportType(const string& type) {
        vector<Product*> filtered;
        for (size_t i = 0; i < products.size(); i++) {
            Product* p = products[i];
            if (p->info.type == type)
                filtered.push_back(p);
        }
        sort(filtered.begin(), filtered.end(),
            [](Product* a, Product* b) { return a->name < b->name; });
        for (size_t i = 0; i < filtered.size(); i++) {
            Product* p = filtered[i];
            cout << p->info.model << " " << p->price << " " << p->name << '\n';
        }
    }
};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Store s("products.txt");
    int c;
    do {
        cout << "\n1-Додати \n2-Показати \n3-Видалити \n4-Редагувати "
            "\n5-Сортувати(назва) \n6-Сортувати(ціна) "
            "\n7-Пошук фірми \n8-Вибірка \n9-Середня "
            "\n10-Зміна ціни \n11-Звіт \n0-Вихід\n";
        cin >> c;
        if (c == 1) s.add();
        else if (c == 2) s.showAll();
        else if (c == 3) { string n; cout << "Назва: "; cin >> n; s.del(n); }
        else if (c == 4) { string n; cout << "Назва: "; cin >> n; s.edit(n); }
        else if (c == 5) s.sortByName();
        else if (c == 6) s.sortByPrice();
        else if (c == 7) { string f; cout << "Фірма: "; cin >> f; s.searchFirm(f); }
        else if (c == 8) { string t; double x, y; cout << "Тип, X, Y: "; cin >> t >> x >> y; s.selectTypePrice(t, x, y); }
        else if (c == 9) { string t; cout << "Тип: "; cin >> t; s.averageType(t); }
        else if (c == 10) { string t; double p; cout << "Тип і %: "; cin >> t >> p; s.changePriceType(t, p); }
        else if (c == 11) { string t; cout << "Тип: "; cin >> t; s.reportType(t); }
    } while (c != 0);
}
