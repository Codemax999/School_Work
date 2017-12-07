import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class FacebookService {

  // --- [Constructor] ---
  constructor(public http: Http) { }


  // --- [Venues near lat lng] ---
  getVenues = (latlng: Array<number>): Promise<any> => {

    return new Promise((resolve, reject) => {

      // query details
      const center = `${String(latlng[0])},${String(latlng[1])}`;
      const key = '535769779959865|yC4RI-mpARKdAHG9gS9LILDhwI8';
      const distance = 4023.36;
      const categories = 'ARTS_ENTERTAINMENT';
      const fields = 'name, category_list';
      const path = `https://graph.facebook.com/v2.11/search?type=place&center=${center}&distance=${distance}&fields=${fields}&access_token=${key}`;

      let venues = [];
      let counter = 0;
      
      this.venueApi(path)
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        // .then(res => {

        //   if (res.venues) res.venues.map(x => venues.push(x));
        //   if (res.nextPath) return this.venueApi(res.nextPath);
        //   else return;
        // })
        .then(res => {

          if (res.venues) res.venues.map(x => venues.push(x));
          else return;
        })
        .then(() => {
          
          const payload = {
            venues: venues
          };

          resolve(payload);
        });
    });
  }

  // venue api
  venueApi = (path: string): Promise<any> => {

    return new Promise((resolve, reject) => {

      // venue names 
      let venues = [];

      // get venues
      this.http.get(path).subscribe(res => {

        // for each venue get events
        const venue = res.json().data;
        venue.map((x, i) => {

          // Page Categories
          const verifyType = ['Bar','Dance & Night Club','Lounge','Cocktail Bar','Live Music Venue'];

          // get all events if venue is correct category
          const verify = x.category_list.map(category => verifyType.includes(category.name));
          if (verify.includes(true)) venues.push(x);

          // return
          if (i === venue.length - 1) {

            const data = {
              venues: venues,
              nextPath: res.json().paging.next
            };

            resolve(data);
          }
        });
      });
    });
  }


  // --- [Venues Events] ---
  // paths to all local pages events
  buildEventPaths = (payload: any): Promise<any> => {

    return new Promise((resolve, reject) => {

      // event urls
      let eventPaths = [];

      // loop venues
      payload.venues.map((x, i) => {

        // page event path
        const time = 'upcoming';
        const key = '535769779959865|yC4RI-mpARKdAHG9gS9LILDhwI8';
        const eventPath = `https://graph.facebook.com/v2.11/${x.id}/events?include_canceled=${false}&time_filter=${time}&access_token=${key}`;
        eventPaths.push(eventPath);

        // return 
        if (i === payload.venues.length - 1) {

          payload.eventPaths = eventPaths;
          resolve(payload);
        }
      });
    });
  }

  // events from paths
  getAllEvents = (payload: any): Promise<any> => {

    return new Promise((resolve, reject) => {

      // all events and counter
      let allEvents = [];
      let counter = 1;

      // loop for each venue and get list of events
      payload.eventPaths.map(x => {

        this.http.get(x).subscribe(eventRes => {

          // validate for data and add to array
          const events = eventRes.json().data;
          if (events.length > 0) events.map(ev => allEvents.push(ev));

          // update counter and return payload
          if (counter !== payload.eventPaths.length) counter++;
          else {

            payload.allEvents = allEvents;
            resolve(payload);
          }
        });
      });
    });
  }

  // sort events
  sortEvents(payload: any): Promise<any> {

    return new Promise((resolve, reject) => {

      // map of events by key of event start
      let dates = new Map();

      // return if no events
      if (!payload.allEvents.length) {

        payload.dates = dates;
        return resolve(payload);
      }

      // filter for any past dates or duplicates
      const currentMilli = moment().valueOf();
      payload.allEvents = payload.allEvents.filter(x => currentMilli <= moment(x.start_time).valueOf());
      payload.allEvents = Array.from(payload.allEvents.reduce((a, b) => a.set(b.id, b), new Map()).values());
      payload.allEvents.map((x, i) => {

        // create timestamp for day of event to be used with Map
        const startDate = moment(x.start_time).startOf('day').valueOf();

        // if timestamp key already exists update array, else set initial key
        if (dates.has(startDate)) {

          let prev = Array.from(dates.get(startDate));
          prev.push(x);
          dates.set(startDate, prev);

        } else dates.set(startDate, [x]);

        // return
        if (i === payload.allEvents.length - 1) {

          payload.dates = dates;
          resolve(payload);
        }
      });
    });
  }
}
