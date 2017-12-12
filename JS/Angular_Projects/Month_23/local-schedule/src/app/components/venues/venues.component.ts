import { Component, Input } from '@angular/core';
import { Venue } from '../../interfaces/venue';

@Component({
  selector: 'app-venues',
  templateUrl: './venues.component.html',
  styleUrls: ['./venues.component.scss']
})
export class VenuesComponent {

  // --- Component Variables ---
  @Input() venues: Array<Venue>;
}
