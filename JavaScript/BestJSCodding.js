//Use Consistent Code Formatting

// Bad
function foo() {console.log("Hello");}

// Good
function foo() {
  console.log("Hello");
}

//Use Descriptive Variable and Function Names
//Names should clearly explain the purpose.

// Bad
const a = 1;

// Good
const userCount = 1;

//Use Comments Wisely
//Explain why, not what, and avoid redundant comments.

// Bad
// Increment count by 1
count++;

// Good
// Increase count when the user clicks the "Add" button
count++;


//Use Modern JavaScript Features

// Use let and const Instead of var
// Use const for constants and let for variables that need reassignment.
// Avoid var due to hoisting and scoping issues.

// Bad
var x = 10;

// Good
let x = 10; // Reassignable
const y = 20; // Constant

//Use Template Literals
//Avoid string concatenation; prefer template literals.

// Bad
const messages = 'Hello, ' + name + '!';

// Good
const messagees = `Hello, ${name}!`;

//Use Default Parameters
//Set default values for function arguments.

function greet(name = 'Guest') {
    console.log(`Hello, ${name}!`);
  }
  
  greet(); // Output: Hello, Guest!

//Use Arrow Functions for Short Callbacks
//Use arrow functions for anonymous and inline callbacks.

// Bad
setTimeout(function () {
    console.log('Hello');
  }, 1000);
  
  // Good
setTimeout(() => console.log('Hello'), 1000);

// Avoid Common Mistakes

// Avoid Using == (Loose Equality)
// Always use strict equality (===) to avoid type coercion.

// Bad
console.log(0 == ''); // true

// Good
console.log(0 === ''); // false

//Avoid Deep Nesting
//Refactor deeply nested code into smaller functions.

// Bad
if (user) {
    if (user.profile) {
      if (user.profile.name) {
        console.log(user.profile.name);
      }
    }
  }
  
  // Good
  if (user?.profile?.name) {
    console.log(user.profile.name);
  }
  

  //Code Maintainability
  //Avoid Long Functions
  //Split long functions into smaller, reusable ones.

  // Bad
function processUser(user) {
    validateUser(user);
    saveUserToDB(user);
    notifyUser(user);
  }
  
  // Good
  function processUser(user) {
    validate(user);
    save(user);
    notify(user);
  }

  // 
  