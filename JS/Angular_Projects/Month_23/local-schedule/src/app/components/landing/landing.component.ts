import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

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
}
