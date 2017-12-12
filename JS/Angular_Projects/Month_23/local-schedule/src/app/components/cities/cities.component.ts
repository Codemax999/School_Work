import { Component } from '@angular/core';
import { City } from '../../interfaces/city';

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
    const cityNames = [
      'Wynwood', 
      'Austin', 
      'West Palm Beach', 
      'Tokyo',
      'Portland', 
      'Sydney',
      'Vancouver',
      'San Jose',
    ];
    
    const cityImgPaths = [
      'assets/city/wynwood.jpg',
      'assets/city/austin.jpg',
      'assets/city/west_palm.jpg',
      'assets/city/tokyo.jpg',
      'assets/city/portland.jpg',
      'assets/city/sydney.jpg',
      'assets/city/vancouver.jpg',
      'assets/city/san_jose.jpg',
    ];

    cityNames.map((x, i) => {

      const newCity = <City> {
        name: x,
        img: cityImgPaths[i]
      };

      this.cities = [...this.cities, newCity];
    });    
  }
}
