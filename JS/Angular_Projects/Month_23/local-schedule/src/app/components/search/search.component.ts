import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {

  // --- Component Variables ---
  form: FormGroup;
  city: string = '';


  // --- LifeCycle ---
  ngOnInit() {

    // initialize form 
    this.form = new FormGroup({
      city: new FormControl(this.city, Validators.maxLength(50))
    });
  }


  // --- Is Input in Header ---
  isHeader(): boolean {
    
    if (window.location.pathname === '/results') return true;
    else return false;
  }
}
