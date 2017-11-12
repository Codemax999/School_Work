// --- Utitility ---
class Utils {

  // get total rating
  static calcTotal(service, food) {
    return (Number(service) + Number(food)) / 2;
  }

  // sort data 
  static sortData(payload) {
    return payload.sort((a, b) => b.numScore - a.numScore);
  }

  // add star to rating
  static addStar(num) {
    return `${num} Star`;
  }

  // validate form
  static validateForm() {

    // form 
    const reviewForm = document.forms.reviewForm;

    // valid count
    let validCount = 0;
    validCount += reviewForm.reviewName.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewName.value.trim().length !== 0 ? 0 : 1;
    validCount += reviewForm.reviewService.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewService.value !== 'Choose a rating' ? 0 : 1;
    validCount += reviewForm.reviewFood.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewFood.value !== 'Choose a rating' ? 0 : 1;

    // toggle submit button disabled
    const submitBtn = document.querySelector('.submit');
    if (validCount === 0) submitBtn.disabled = false;
    else submitBtn.disabled = true;
  }

  // reset form and submit button 
  static resetForm() {
    document.forms.reviewForm.reset();
    document.querySelector('.submit').disabled = true;
  }

  // show table
  static showTable() {
    document.querySelector('.empty').classList.add('hidden');
    document.querySelector('.table').classList.remove('hidden');
  }

  // clear table
  static clearTable() {
    document.querySelector('tBody').innerHTML = '';
  }
}