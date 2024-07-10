// 1. ################################################################
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
  };
  
  let sum = 0;
  for (let key in salaries) {
    sum += salaries[key];
  }
  
  console.log(sum);
  
//   2. ################################################################
function multiplyNumeric(obj) {
    for (let key in obj) {
      if (typeof obj[key] === 'number') {
        obj[key] *= 2;
      }
    }
  }
  
  let menu = {
    width: 200,
    height: 300,
    title: "My menu"
  };
  
  multiplyNumeric(menu);
  
  console.log(menu);

// 3.################################################################
function checkEmailId(str) {

  str = str.toLowerCase();

  let atIndex = str.indexOf('@');
  let dotIndex = str.indexOf('.');

  if (atIndex > 0 && dotIndex > atIndex + 1) {
    return true;
  } else {
    return false;
  }
}


console.log(checkEmailId("example@domain.com"));
console.log(checkEmailId("example.domain@com"));
console.log(checkEmailId("example@domaincom"));
console.log(checkEmailId("example@domain.c"));

// 4. ################################################################
function truncate(str, maxlength) {
  if (str.length > maxlength) {
    return str.slice(0, maxlength - 3) + '...';
  } else {
    return str;
  }
}

// Example usage:
console.log(truncate("What I'd like to tell on this topic is:", 20)); // "What I'd like to te..."
console.log(truncate("Hi everyone!", 20)); // "Hi everyone!"

// 5. #################################################################

// Step 1: Create an array styles with items "James" and "Brennie"
let styles = ["James", "Brennie"];
console.log(styles);

// Step 2: Append "Robert" to the end
styles.push("Robert");
console.log(styles);

// Step 3: Replace the value in the middle by "Calvin"
let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles);

// Step 4: Remove the first value of the array and show it
let firstValue = styles.shift();
console.log(firstValue); 
console.log(styles); 

// Step 5: Prepend "Rose" and "Regal" to the array
styles.unshift("Rose", "Regal");
console.log(styles);

