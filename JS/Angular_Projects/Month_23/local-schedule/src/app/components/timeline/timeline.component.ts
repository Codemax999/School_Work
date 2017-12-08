import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.scss']
})
export class TimelineComponent {

  // --- Component Variables ---
  @Input() venues: Array<any>;
  @Input() schedule: Array<any>;


  // remove venues that are booked
  filterVenues(venues: Array<any>): Array<any> {

    venues = venues.map(x => x.place.name);
    return this.venues.filter(x => !venues.includes(x.name));
  }
}
