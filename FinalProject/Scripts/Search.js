function search() {
    //Set up the variables.
    var searchKey = document.querySelector("#txtsearch").value.trim().toLowerCase();
    let rows = document.querySelector("#txtsearch").length;
    let results = 0;
    document.querySelectorAll("tbody tr").forEach(c => {
        let currentText = c.textContent.toLowerCase();
        //Brings back the results if there's nothing in the search results.
        if (searchKey.length != -1) {
            if (currentText.includes(searchKey)) {
                c.classList.remove("hide")
                results += 1;
                console.log("Hope.")
            }
            //Hides the results depending if there's something
            //Inside of the search box.
            else {
                c.classList.add("hide");
                console.log("Nope");
            }
        }

    })
}
