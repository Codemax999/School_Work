// --- MAIN SECTION ---

// --- ONLOAD ---

//call function 
window.onload = familyJobInital;


// --- FUNCTIONS ---

//regular print out
function familyJobInital() 
{
  //family and jobs function
  let familyMembers = ['Mother', 'Father', 'Brother', 'Sister'];
  let familyJobs = ['Teacher', 'Helicopter Inspector', 'Pilot', 'Entrepreneur'];

  //loop through arrays and print out
  for (let i = 0; i < familyMembers.length; i++)
  {
    console.log('My', familyMembers[i], 'is a', familyJobs[i]);
  }

  //pass arrays to mashup function
  familyJobMashup(familyMembers, familyJobs);
}

//sorted and reversed print out
function familyJobMashup(members, jobs)
{
  //sort and reverse arrays
  members.sort().reverse();
  jobs.sort().reverse();

  //print out 
  console.log('--- MASHED UP ---');

  //loop through new arrays
  for (let i = 0; i < members.length; i++)
  {
    console.log('My', members[i], 'is a', jobs[i]);
  }
}