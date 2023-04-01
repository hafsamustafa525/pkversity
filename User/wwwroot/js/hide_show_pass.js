function myFunction() {
    var x = document.getElementById("form3Example4");
  if (x.type === "password") {
    x.type = "text";
  } else {
    x.type = "password";
  }
}