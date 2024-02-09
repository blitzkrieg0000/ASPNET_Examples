function CalculateHash() {
    let password_element = document.getElementById("password");
    if (password_element != null) {
        let hash = ""
        let password = password_element.value

        if (password != null) {
            hash = sha3_512(password)
        }

        var hashed_element = document.getElementById("hashed");
        if (hashed_element != null) {
            hashed_element.value = hash;
        }
    }
}