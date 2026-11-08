// =========================================================================
// Serie A 2026/27 - Tüm Takımların Gerçek Oyuncu Kadroları (Mevkilere Göre)
// =========================================================================

const ROSTERS = {
    "Atalanta": {
        "Kaleciler": ["Marco Carnesecchi", "Rui Patrício", "Francesco Rossi"],
        "Defans": ["Berat Djimsiti", "Isak Hien", "Sead Kolašinac", "Odilon Kossounou", "Raoul Bellanova", "Davide Zappacosta", "Matteo Ruggeri"],
        "Orta Saha": ["Éderson", "Marten de Roon", "Mario Pašalić", "Lazar Samardžić", "Marco Brescianini", "Juan Cuadrado"],
        "Forvet": ["Ademola Lookman", "Mateo Retegui", "Charles De Ketelaere", "Nicolò Zaniolo"]
    },
    "Bologna": {
        "Kaleciler": ["Łukasz Skorupski", "Federico Ravaglia"],
        "Defans": ["Sam Beukema", "Jhon Lucumí", "Stefan Posch", "Juan Miranda", "charalampos Lykogiannis", "Lorenzo De Silvestri"],
        "Orta Saha": ["Remo Freuler", "Michel Aebischer", "Lewis Ferguson", "Nikola Moro", "Tommaso Pobega", "Giovanni Fabbian"],
        "Forvet": ["Riccardo Orsolini", "Santiago Castro", "Dan Ndoye", "Thijs Dallinga", "Jens Odgaard"]
    },
    "Cagliari": {
        "Kaleciler": ["Simone Scuffet", "Alen Sherri"],
        "Defans": ["Yerry Mina", "Sebastiano Luperto", "Gabriele Zappa", "Tommaso Augello", "Adam Obert"],
        "Orta Saha": ["onatan Razvan Marin", "Michel Adopo", "Antoine Makoumbou", "Nicolas Viola", "Gianluca Gaetano", "Nadir Zortea"],
        "Forvet": ["Roberto Piccoli", "Zito Luvumbo", "Gianluca Lapadula", "Leonardo Pavoletti"]
    },
    "Como": {
        "Kaleciler": ["Emil Audero", "Pepe Reina"],
        "Defans": ["Alberto Dossena", "Marc-Oliver Kempf", "Alberto Moreno", "Ignace Van Der Brempt", "Edoardo Goldaniga"],
        "Orta Saha": ["Nico Paz", "Sergi Roberto", "Máximo Perrone", "Lucas Da Cunha", "Gabriel Strefezza"],
        "Forvet": ["Patrick Cutrone", "Andrea Belotti", "Alieu Fadera", "Alessandro Gabrielloni"]
    },
    "Fiorentina": {
        "Kaleciler": ["David de Gea", "Pietro Terracciano"],
        "Defans": ["Dodô", "Robin Gosens", "Luca Ranieri", "ietro Comuzzo", "Lucas Martínez Quarta", "Fabiano Parisi"],
        "Orta Saha": ["Yacine Adli", "Danilo Cataldi", "Rolando Mandragora", "Edoardo Bove", "Andrea Colpani", "Amir Richardson"],
        "Forvet": ["Moise Kean", "Albert Guðmundsson", "Lucas Beltrán", "Jonathan Ikoné", "Christian Kouamé"]
    },
    "Frosinone": {
        "Kaleciler": ["Michele Cerofolini", "Alessandro Sorrentino"],
        "Defans": ["riccardo Marchizza", "Ilario Monterisi", "Davide Biraschi", "Anthony Oyono", "Giorgio Cittadini"],
        "Orta Saha": ["Francesco Gelli", "Ebrima Darboe", "Luca Garritano", "José Machín"],
        "Forvet": ["Giuseppe Ambrosino", "Anthony Partipilo", "Pecorino Emanuele", "Farès Ghedjemis"]
    },
    "Genoa": {
        "Kaleciler": ["Pierluigi Gollini", "Nicola Leali"],
        "Defans": ["Koni De Winter", "Johan Vásquez", "Mattia Bani", "Aarón Martín", "Stefano Sabelli"],
        "Orta Saha": ["Morten Frendrup", "Milan Badelj", "Ruslan Malinovskyi", "Morten Thorsby", "Fabio Miretti"],
        "Forvet": ["Andrea Pinamonti", "Vitinha", "Junior Messias", "Caleb Ekuban", "Mario Balotelli"]
    },
    "Inter": {
        "Kaleciler": ["Yann Sommer", " Josep Martínez", "Raffaele Di Gennaro"],
        "Defans": ["Alessandro Bastoni", "Benjamin Pavard", "Francesco Acerbi", "Stefan de Vrij", "Federico Dimarco", "Denzel Dumfries", "Matteo Darmian", "Carlos Augusto"],
        "Orta Saha": ["Hakan Çalhanoğlu", "Nicolò Barella", "Henrikh Mkhitaryan", "Davide Frattesi", "Piotr Zieliński", "Kristjan Asllani"],
        "Forvet": ["Lautaro Martínez", "Marcus Thuram", "Mehdi Taremi", "Marko Arnautović"]
    },
    "Juventus": {
        "Kaleciler": ["Michele Di Gregorio", "Mattia Perin", "Carlo Pinsoglio"],
        "Defans": ["Gleison Bremer", "Federico Gatti", "Pierre Kalulu", "Andrea Cambiaso", "Danilo", "Nicolò Savona", "Juan Cabal"],
        "Orta Saha": ["Teun Koopmeiners", "Manuel Locatelli", "Khéphren Thuram", "Douglas Luiz", "Weston McKennie", "Nicolò Fagioli"],
        "Forvet": ["Dušan Vlahović", "Kenan Yıldız", "Francisco Conceição", "Nicolás González", "Timothy Weah", "Arkadiusz Milik"]
    },
    "Lazio": {
        "Kaleciler": ["Ivan Provedel", "Christos Mandas"],
        "Defans": ["Alessio Romagnoli", "Mario Gila", "Nuno Tavares", "Manuel Lazzari", "Adam Marušić", "Patric"],
        "Orta Saha": ["Matteo Guendouzi", "Nicolò Rovella", "Matías Vecino", "Fisayo Dele-Bashiru", "Gaetano Castrovilli"],
        "Forvet": ["Mattia Zaccagni", "Taty Castellanos", "Boulaye Dia", "Pedro", "Gustav Isaksen", "Tijjani Noslin"]
    },
    "Lecce": {
        "Kaleciler": ["Wladimiro Falcone", "Christian Früchtl"],
        "Defans": ["Federico Baschirotto", "Kialonda Gaspar", "Antonino Gallo", "Frédéric Guilbert"],
        "Orta Saha": ["Ylber Ramadani", "Balthazar Pierret", "Rémi Oudin", "Lassana Coulibaly", "Hamza Rafia"],
        "Forvet": ["Nikola Krstović", "Lameck Banda", "Ante Rebić", "Patrick Dorgu", "Tete Morente"]
    },
    "Milan": {
        "Kaleciler": ["Mike Maignan", "Marco Sportiello", "Lorenzo Torriani"],
        "Defans": ["Theo Hernández", "Fikayo Tomori", "Matteo Gabbia", "Strahinja Pavlović", "Emerson Royal", "Davide Calabria", "Malick Thiaw"],
        "Orta Saha": ["Tijjani Reijnders", "Youssouf Fofana", "Ruben Loftus-Cheek", "Yunus Musah", "Ismaël Bennacer"],
        "Forvet": ["Rafael Leão", "Christian Pulisic", "Álvaro Morata", "Tammy Abraham", "Samuel Chukwueze", "Noah Okafor"]
    },
    "Monza": {
        "Kaleciler": ["Stefano Turati", "Semuel Pizzignacco"],
        "Defans": ["Pablo Marí", "Armando Izzo", "Danilo D'Ambrosio", "Georgios Kyriakopoulos", "Pedro Pereira"],
        "Orta Saha": ["Matteo Pessina", "Warren Bondo", "Alessandro Bianco", "Roberto Gagliardini"],
        "Forvet": ["Milan Đurić", "Daniel Maldini", "Dany Mota", "Gianluca Caprari"]
    },
    "Napoli": {
        "Kaleciler": ["Alex Meret", "Elia Caprile"],
        "Defans": ["Alessandro Buongiorno", "Amir Rrahmani", "Giovanni Di Lorenzo", "Mathías Olivera", "Leonardo Spinazzola", "Juan Jesus"],
        "Orta Saha": ["Scott McTominay", "Stanislav Lobotka", "André-Frank Zambo Anguissa", "Billy Gilmour", "Michael Folorunsho"],
        "Forvet": ["Khvicha Kvaratskhelia", "Romelu Lukaku", "Matteo Politano", "David Neres", "Giovanni Simeone", "Giacomo Raspadori"]
    },
    "Parma": {
        "Kaleciler": ["Zion Suzuki", "Edoardo Corvi"],
        "Defans": ["Enrico Delprato", "Botond Balogh", "Emanuele Valeri", "Woyo Coulibaly"],
        "Orta Saha": ["Adrián Bernabé", "Simon Sohm", "Mandela Keita", "Hernani", "Nahuel Estévez"],
        "Forvet": ["Dennis Man", "Ange-Yoan Bonny", "Valentin Mihăilă", "Matteo Cancellieri", "Pontus Almqvist"]
    },
    "Roma": {
        "Kaleciler": ["Mile Svilar", "Mathew Ryan"],
        "Defans": ["Gianluca Mancini", "Evan Ndicka", "Mario Hermoso", "Angeliño", "Zeki Çelik", "Mats Hummels"],
        "Orta Saha": ["Bryan Cristante", "Lorenzo Pellegrini", "Manu Koné", "Leandro Paredes", "Niccolò Pisilli", "Nicola Zalewski"],
        "Forvet": ["Paulo Dybala", "Artem Dovbyk", "Matías Soulé", "Stephan El Shaarawy", "Tommaso Baldanzi", "Eldor Shomurodov"]
    },
    "Sassuolo": {
        "Kaleciler": ["Horatiu Moldovan", "Giacomo Satalino"],
        "Defans": ["Josh Doig", "Filippo Romagna", "Cas Odenthal", "Jeremy Toljan"],
        "Orta Saha": ["Kristian Thorstvedt", "Daniel Boloca", "Pedro Obiang", "Edoardo Iannoni"],
        "Forvet": ["Domenico Berardi", "Armand Laurienté", "Samuele Mulattieri", "Nicholas Pierini"]
    },
    "Torino": {
        "Kaleciler": ["Vanja Milinković-Savić", "Alberto Paleari"],
        "Defans": ["Saúl Coco", " Guillermo Maripán", "Adam Masina", "Valentino Lazaro", "Borna Sosa"],
        "Orta Saha": ["Samuele Ricci", "Ivan Ilić", "Nikola Vlašić", "Karol Linetty", "Gvidas Gineitis"],
        "Forvet": ["Duván Zapata", "Che Adams", "Antonio Sanabria", "Yann Karamoh"]
    },
    "Udinese": {
        "Kaleciler": ["Maduka Okoye", "Răzvan Sava"],
        "Defans": ["Jaka Bijol", "Lautaro Giannetti", "Kingsley Ehizibue", "Hassane Kamara", "Jordan Zemura"],
        "Orta Saha": ["Jesper Karlström", "Sandi Lovrić", "Martín Payero", "Jurgen Ekkelenkamp"],
        "Forvet": ["Lorenzo Lucca", "Florian Thauvin", "Keinan Davis", "Brenner", "Alexis Sánchez"]
    },
    "Venezia": {
        "Kaleciler": ["Filip Stanković", "Jesse Joronen"],
        "Defans": ["Jay Idzes", "Michael Svoboda", "Marin Šverko", "Francesco Zampano", "Antonio Candela"],
        "Orta Saha": ["Hans Nicolussi Caviglia", "Alfred Duncan", "Gianluca Busio", "Mikael Egill Ellertsson"],
        "Forvet": ["Joel Pohjanpalo", "Gaetano Oristanio", "John Yeboah", "Christian Gytkjær"]
    },
    "Sampdoria": {
        "Kaleciler": ["Marco Silvestri", "Paolo Vismara"],
        "Defans": ["Bartosz Bereszyński", "Simone Romagnoli", "Alex Ferrari", "Nicholas Ioannou"],
        "Orta Saha": ["Melle Meulensteen", "Gerard Yepes", "Ebenezer Akinsanmiro", "Pajtim Kasami"],
        "Forvet": ["Massimo Coda", "Gennaro Tutino", "Fabio Borini", "Estanis Pedrola"]
    },
    "Salernitana": {
        "Kaleciler": ["Luigi Sepe", "Vincenzo Fiorillo"],
        "Defans": ["Dylan Bronn", "Gian Marco Ferrari", "Paweł Jaroszyński", "Petar Stojanović"],
        "Orta Saha": ["Giulio Maggiore", "Roberto Soriano", "Lorenzo Amatucci", "Franco Tongya"],
        "Forvet": ["Simy", "Daniele Verde", "Ernesto Torregrossa", "Jayden Braaf"]
    }
};

function openEventModal() {
    document.getElementById('event-modal').showModal();
}

// Olay Türü değiştikçe form alanlarını değiştir (Gol, Kart, Değişiklik)
function onEventTypeChange() {
    const type = document.getElementById('ev-type').value;
    document.getElementById('sec-goal').style.display = (type === 'Goal') ? 'block' : 'none';
    document.getElementById('sec-card').style.display = (type === 'Card') ? 'block' : 'none';
    document.getElementById('sec-sub').style.display = (type === 'Substitution') ? 'block' : 'none';
}

// Takım seçildiğinde o takımın gerçek oyuncularını optgroup yapısıyla doldur
function onTeamChange() {
    const teamSelect = document.getElementById('ev-team');
    const selectedOption = teamSelect.options[teamSelect.selectedIndex];
    const teamName = selectedOption.dataset.team; // Örn: "Inter", "Milan", "Roma", "Juventus"

    const dropdowns = document.querySelectorAll('.player-dropdown');
    if (!teamName || !ROSTERS[teamName]) {
        dropdowns.forEach(dd => dd.innerHTML = '<option value="">Lütfen önce takım seçiniz...</option>');
        return;
    }

    const roster = ROSTERS[teamName];
    let html = '<option value="">Oyuncu seçiniz...</option>';

    for (const [position, players] of Object.entries(roster)) {
        html += `<optgroup label="${position}">`;
        players.forEach(p => {
            html += `<option value="${p}">${p}</option>`;
        });
        html += `</optgroup>`;
    }

    dropdowns.forEach(dd => dd.innerHTML = html);
}
