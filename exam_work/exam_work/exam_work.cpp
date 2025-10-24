#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <algorithm>
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
};

class Store {
    vector<Product*> products;
    string filename;
public:
    Store(string file) : filename(file) { load(); }
    ~Store() { for (auto p : products) delete p; }

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
        for (auto p : products)
            f << p->name << ' ' << p->price << ' ' << p->info.type << ' ' << p->info.firm << ' ' << p->info.model << ' ' << p->info.extra.warranty << '\n';
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
        save();
    }

    void showAll() {
        for (auto p : products)
            cout << p->name << " " << p->price << "грн " << p->info.type << " " << p->info.firm << " " << p->info.model << " гарантія:" << p->info.extra.warranty << "міс\n";
    }

    void del(const string& name) {
        for (auto it = products.begin(); it != products.end();)
            if ((*it)->name == name) { delete* it; it = products.erase(it); }
            else ++it;
        save();
    }

    void edit(const string& name) {
        for (auto p : products)
            if (p->name == name) {
                cout << "Нова ціна: "; cin >> p->price;
                if (p->price <= 0) p->price = 1;
            }
        save();
    }

    void sortByName() {
        sort(products.begin(), products.end(), [](Product* a, Product* b) { return a->name < b->name; });
    }

    void sortByPrice() {
        sort(products.begin(), products.end(), [](Product* a, Product* b) { return a->price < b->price; });
    }

    void searchFirm(const string& firm) {
        for (auto p : products)
            if (p->info.firm == firm)
                cout << p->name << " " << p->price << " " << p->info.type << " " << p->info.model << '\n';
    }

    void selectTypePrice(const string& type, double x, double y) {
        for (auto p : products)
            if (p->info.type == type && p->price >= x && p->price <= y)
                cout << p->name << " " << p->price << '\n';
    }

    void averageType(const string& type) {
        double sum = 0; int count = 0;
        for (auto p : products)
            if (p->info.type == type) { sum += p->price; count++; }
        if (count) cout << "Середня ціна: " << sum / count << '\n';
    }

    void changePriceType(const string& type, double percent) {
        for (auto p : products)
            if (p->info.type == type)
                p->price += p->price * percent / 100.0;
        save();
    }

    void reportType(const string& type) {
        vector<Product*> filtered;
        for (auto p : products)
            if (p->info.type == type)
                filtered.push_back(p);
        sort(filtered.begin(), filtered.end(), [](Product* a, Product* b) { return a->name < b->name; });
        for (auto p : filtered)
            cout << p->info.model << " " << p->price << " " << p->name << '\n';
    }
};

int main() {
    Store s("products.txt");
    int c;
    do {
        cout << "\n1-Додати 2-Показати 3-Видалити 4-Редагувати 5-Сортувати(назва) 6-Сортувати(ціна) 7-Пошук фірми 8-Вибірка 9-Середня 10-Зміна ціни 11-Звіт 0-Вихід\n";
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
