//Numeric Separators
//Improve readability of large numbers by using _ as a separator.

const billion = 1_000_000_000;
console.log(billion); // Output: 1000000000


// Logical Nullish Assignment (??=)
//Assign a value only if the variable is null or undefined.
let userName = null;
userName ??= 'Default User';
console.log(userName); // Output: Default User


//Nullish Coalescing Operator (??)
// Handle null or undefined with more clarity compared to ||.

let a = null;
let b = a ?? 'Default Value'; // If 'a' is null/undefined, use 'Default Value'
console.log(b); // Output: Default Value


//Optional Chaining (?.)
//Safely access nested object properties without throwing errors.

const user = { profile: { name: 'Shubham' } };
console.log(user.profile?.name); // Output: Shubham
console.log(user.address?.city); // Output: undefined (no error)

//Short-Circuiting with && and ||
// Simplify conditional statements.

const isLoggedIn = true;
isLoggedIn && console.log('Welcome!'); // Short-circuits and prints Welcome!

const username = '' || 'Guest'; // Fallback for falsy values
console.log(username); // Output: Guest


//Array flat() and flatMap()
//Flatten arrays or map and flatten in one go.

const arr = [1, [2, [3, 4]]];
console.log(arr.flat(2)); // Output: [1, 2, 3, 4]

const numbers = [1, 2, 3];
console.log(numbers.flatMap((n) => [n, n * 2])); // Output: [1, 2, 2, 4, 3, 6]

// String replaceAll()
//Replace all occurrences of a substring easily.

const str = 'I like cats. Cats are cute.';
console.log(str.replaceAll('Cats', 'Dogs')); // Output: I like cats. Dogs are cute.

//Rest and Spread Operator
//Collect the rest of arguments or expand values.

//Rest Example:
function sum(...numbers) {
    return numbers.reduce((a, b) => a + b, 0);
  }
  console.log(sum(1, 2, 3, 4)); // Output: 10

//Spread Example:
const arr1 = [1, 2];
const arr2 = [...arr1, 3, 4];
console.log(arr2); // Output: [1, 2, 3, 4]

//Set and Map
//Use Set for unique values and Map for key-value pairs with any key type.

//Example - Set:
const numberss = new Set([1, 2, 3, 3, 2]);
console.log(numberss); // Output: Set { 1, 2, 3 }

//Example - Map:
const map = new Map();
map.set('name', 'John');
map.set(1, 'One');
console.log(map.get(1)); // Output: One

//Logical Assignment Operators
//Combine logical operations and assignments.

let value = null;
value ??= 'Default';
console.log(value); // Output: Default

let data = 5;
data &&= 10; // If 'b' is truthy, assign 10
console.log(data); // Output: 10


//Array at() Method
//Access array elements using positive or negative indices.
const array = [10, 20, 30];
console.log(array.at(-1)); // Output: 30


//Blob URLs for File Handling
//Create downloadable URLs for dynamic data.

const blob = new Blob(['Hello World'], { type: 'text/plain' });
const url = URL.createObjectURL(blob);

const link = document.createElement('a');
link.href = url;
link.download = 'example.txt';
link.click();

URL.revokeObjectURL(url); // Cleanup


//CSS-in-JS with Template Literals
//Dynamically generate styles using template literals.

const style = `
  background-color: blue;
  color: white;
  padding: 10px;
`;

document.body.style.cssText = style;

//BroadcastChannel API for Cross-Tab Communication
//Share messages between tabs of the same origin.
//Note Only work on same sabe instance not in Incognito mode
const channel = new BroadcastChannel('test_channel');
channel.postMessage('Hello from Tab 1');

channel.onmessage = (event) => {
  console.log('Received:', event.data);
};


//Default Parameters in Functions
//Provide default values to function arguments.

function greet(name = 'Guest') {
    console.log(`Hello, ${name}`);
  }
  greet(); // Output: Hello, Guest
  greet("Shubham") ; //// Output: Hello, Shubham

//Array includes() Method
//Check if an array contains a specific value.
const numbersArr = [1, 2, 3, 4];
console.log(numbersArr.includes(3)); // Output: true
console.log(numbersArr.includes(5)); // Output: false


//Defer Script Execution (defer and async)
//Optimize script loading in the browser.

{/* <script src="script.js" defer></script> <!-- Loads after parsing the HTML --> */}
{/* <script src="script.js" async></script> <!-- Loads asynchronously --> */}


//Array.prototype.every() vs Array.prototype.some()
//every(): Checks if all elements pass a condition.
//some(): Checks if any element passes a condition.

const numbersdata = [1, 2, 3, 4];
console.log(numbersdata.every((n) => n > 0)); // true
console.log(numbersdata.some((n) => n > 3));  // true

//String.prototype.trimStart() and trimEnd()
//Trim whitespace specifically from the start or end of a string.

const strvalue = '   Hello World!   ';
console.log(strvalue.trimStart()); // Output: "Hello World!   "
console.log(strvalue.trimEnd());   // Output: "   Hello World!"

//String split() with Limit
//Limit the number of substrings returned.

const string = 'one,two,three,four';
console.log(string.split(',', 2)); // Output: ['one', 'two']

// Remove Duplicates from Arrays Using Set
// Use Set to ensure all array values are unique.

const arrvalu = [1, 2, 2, 3, 4, 4, 5];
const unique = [...new Set(arrvalu)];
console.log(unique); // Output: [1, 2, 3, 4, 5]


