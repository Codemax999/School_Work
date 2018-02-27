<?

class GoogleApi {

  public function __construct($parent) {

    $this->db = $parent->db;
  }

  public function googleLocation() {

    // api params and url
    $city = 'Orlando';
    $key = 'AIzaSyAMxldDV0j1yorNT3aUMbA9NYX7it0VdI4';
    $url = "https://maps.googleapis.com/maps/api/geocode/json?address={$city}&key={$key}";

    // get data and format
    $locationJson = file_get_contents($url);
    $res = json_decode($locationJson, true);
 
    // validate response status
    if ($res['status'] == 'OK'){
 
        // lat and lng
        $lat = $res['results'][0]['geometry']['location']['lat'];
        $lng = $res['results'][0]['geometry']['location']['lng'];
        $current = $res['results'][0]['formatted_address'];

        // params and url
        $rad = 16093.44;
        $type = 'stadium';
        $placeUrl= "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={$lat},{$lng}&radius={$rad}&type={$type}&key={$key}";

        // get data and format
        $placesJson = file_get_contents($placeUrl);
        $placesRes = json_decode($placesJson, true);

        // validate response status and return results
        if ($placesRes['status'] == 'OK') return array($current, $placesRes['results']);
        else echo 'No places nearby!';

    } else echo "error: {$res['status']}";
  }
}

?>