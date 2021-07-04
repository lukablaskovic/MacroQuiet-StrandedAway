#include <iostream>
#include <algorithm>
#include <list>
using namespace std;
typedef list<int>::iterator iter_type;
typedef reverse_iterator<iter_type> rev_type;

class reverse_list {
public:
	void operator() (list <int> &L) {
		int iteration = 0; int half = L.size() / 2;
		iter_type forward_from(L.begin());
		iter_type forward_until(L.end());
		rev_type reverse_until(forward_from);
		rev_type reverse_from(forward_until);

		while (reverse_from != reverse_until) {
			if (iteration == half) break;
			swap(*reverse_from++, *forward_from++);
			iteration++;
		}
	}
};
//epic komentar
int main() {

	list <int> lista;
	int br = 0;
	int unos;
	cout << "Unos elemenata liste: [0 - prestanak unosa]" << endl;
	while (cin >> unos && unos != 0)
		lista.push_back(unos);
	
	iter_type forward_from(lista.begin());
	iter_type forward_until(lista.end());
	rev_type reverse_until(forward_from);
	rev_type reverse_from(forward_until);

	
	cout << "Ispis liste [prije]: ";
	while(forward_from != forward_until)
		cout << *forward_from++ << " ";

	int iteration = 0;
	int half = lista.size() / 2;
	forward_from = lista.begin();

	cout << "\nZamjena elemenata liste..." << endl;
	while (reverse_from != reverse_until) {
		if (iteration == half) break;
		swap(*reverse_from++, *forward_from++);
		iteration++;
	}

	cout << "\nIspis liste [poslije]: ";
	for(forward_from = lista.begin(); forward_from!=lista.end(); forward_from++)
		cout << *forward_from<< " ";

	reverse_list ()(lista);
	cout << "\nIspis liste [nakon reverse_list funktora]: ";
	for (forward_from = lista.begin(); forward_from != lista.end(); forward_from++)
		cout << *forward_from << " ";
	cout << endl;
	return 0;
}