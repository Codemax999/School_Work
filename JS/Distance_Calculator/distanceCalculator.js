// --- Lat Lng of Address 1 and 2 ---
class Location
{
  constructor(x, y, address)
  {
    this.x = x;
    this.y = y;
    this.address = address;
  }
}


// --- GLOBAL VARIABLES ---

//location one array
let locationOne = [];

//location two array
let locationTwo = [];


// --- HAVERSINE FORMULA ---

//calculate distance between points
checkDistance = (lat1, lng1, lat2, lng2) =>
{
  const R = 6371; //Radius of the earth in km
  const dLat = deg2rad(lat2-lat1);
  const dLng = deg2rad(lng2-lng1); 
  const a = 
    Math.sin(dLat/2) * Math.sin(dLat/2) +
    Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) * 
    Math.sin(dLng/2) * Math.sin(dLng/2)
    ; 
  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a)); 
  const d = R * c; // Distance in km
  return d;

  function deg2rad(deg) { return deg * (Math.PI/180) }
}


//display the distance
displayDistance = () =>
{
  const distanceKm = checkDistance(locationOne[0], locationOne[1], locationTwo[0], locationTwo[1]);
  const distanceM = distanceKm * 0.621371;

  console.log('--- DISTANCE BETWEEN TWO POINTS ---');
  console.log('Kilometers:', distanceKm);
  console.log('Miles:', distanceM);
}


// --- GOOGLE VALIDATION ---

//find lat lng by address
geocodeAddress = (location, seq, cb) =>
{
  //geocoder using address for lat lng
  const geocoder = new google.maps.Geocoder();
  geocoder.geocode({'address': location}, function(results, status) 
  {
    if (status === 'OK') 
    {
      //new address point lat lng Google JSON Object
      const addressDetails = {
        newAddress: results[0].formatted_address,
        newAddressLat: results[0].geometry.location.lat(),
        newAddressLng: results[0].geometry.location.lng()
      }

      //reurn details 
      cb(addressDetails);
    } 
    else { cb(1); }
  });
}

//validate address
validateAddress = (place, seq, cb) =>
{
  geocodeAddress(place, seq, (res) =>
  {
    switch(res)
    {
      case 1:

        //if location error, ask for another address
        cb(false);
        break;

      default:

        //create new location instance and update global variable
        let newLocation = new Location(res.newAddressLat, res.newAddressLng, res.newAddress);

        //ternary to update arrays 
        let selectedArray = seq === 0 ? locationOne : locationTwo;
        selectedArray[0] = newLocation.x;
        selectedArray[1] = newLocation.y;
        selectedArray[2] = newLocation.address;

        //display valid lat lng and place
        let sequenceOrder = seq === 0 ? 'First' : 'Second';
        console.log('[', sequenceOrder, 'Location Info ]')

        //loop info
        const loopId = ['Latitude:', 'Longitude:', 'Location:'];
        let loopCounter = 0;

        //loop to display data
        for (let i of selectedArray)
        {
          console.log(loopId[loopCounter], i);
          loopCounter++;
        }

        //return true
        cb(true);
        break;
    }
  });
}


// --- PROMPTS ---

//ask for city or address 1
getLocations = (index) =>
{
  //counter for location 
  const counter = index;
  //ternary statement for prompt
  const startEnd = counter === 0 ? 'first' : 'second';
  //prompt for location 1
  const place = prompt('Enter your ' + startEnd + ' City, State or Address:');

  //validate entered place
  validateAddress(place, counter, (res) =>
  {
    if (res != true) 
    {
      alert('The location could not be found, please try again');
      getLocations(counter);
    }
    else if (res === true && counter === 1)
    {
      //both addresses are valid, compare them
      displayDistance();
    }
    else 
    {
      //successful location ask for second
      getLocations(1);
    }
  });
}


// --- MAIN SECTION ---

//welcome user
console.log('--- WELCOME TO THE DISTANCE CALCULATOR ---');

//get location one
getLocations(0);