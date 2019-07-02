const uri = "api/ghost";

//FIXME It is necessary minimize this code
//FIXME Define namespace for this code

// Initialize game and set human name
function createGame(name) {
    const item = name;

    // It could be better with await 

    return Promise.resolve($.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item)
    }));
}

// Try to add a new letter for the human
// The computer get a new one too
// Finally return the winner if it exists
function getLetter(letter) {

     // It could be better with await 

    var url = uri + '?letter=' + letter;

    return Promise.resolve($.ajax({
        type: "GET",
        accepts: "application/json",
        url: url,
        contentType: "application/json"
    }));
}


// Get the current word in game
function getStatus() {

    // It could be better with await     
    var url = uri + '/status';

    return Promise.resolve($.ajax({
        type: "GET",
        accepts: "application/json",
        url: url,
        contentType: "application/json"
    }));
}

// Reset de current game in session
function resetGame() {     

    return Promise.resolve($.ajax({
        type: "DELETE",
        accepts: "application/json",
        url: uri,
        contentType: "application/json"
    }));
}