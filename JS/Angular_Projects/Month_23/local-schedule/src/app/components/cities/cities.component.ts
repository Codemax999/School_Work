import { Component } from '@angular/core';

interface City {
  name: string,
  img: string
};

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.scss']
})
export class CitiesComponent { 

  // --- Component Variables ---
  cities: Array<City> = [];


  // --- LifeCycle ---
  ngOnInit() {
    
    // add cities and images to cities array
    const cityNames = ['Wynwood', 'Austin', 'West Palm Beach', 'Portland', 'San Jose'];
    const cityImgPaths = [
      'assets/city/wynwood.jpg',
      'assets/city/austin.jpg',
      'assets/city/west_palm.jpg',
      'assets/city/portland.jpg',
      'assets/city/san_jose.jpg',
    ];

    cityNames.map((x, i) => {

      const newCity = <City> {
        name: x,
        img: cityImgPaths[i]
      };

      this.cities.push(newCity);
    });
  }
}
