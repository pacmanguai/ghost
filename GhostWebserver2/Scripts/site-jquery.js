$(document).ready(function () {

    //FIXME It is necessary minimize this code

    $(document).ready(function () {
        //Initialize
        var xTriggered = 0;
        $('#statistics').hide();
        $('#results').hide();
        $('#spinner').hide();
        $('#word').val("").trigger('change');

        //Tooltips
        var position = { my: 'right center', at: 'right+10 center' };
        position.collision = 'none';
        $('input[type="text"]').tooltip();

        // Validating Form Fields.....
        $('#word').keypress(function (event) {
            if (event.which == 13) {
                event.preventDefault();
            }

            showSpinner();
            var letter = String.fromCharCode(event.which);

            console.log("New char from human: " + letter);

            var promise = getLetter(letter);
            promise.then(
                data => {
                    console.log("Result of new character: " + data);
                    if (data == "") {
                        // still playing
                        // Get new word                       
                        // Change the sytle for simplicity
                        getStatus().then(function (data) {
                            // Update word 
                            console.log("Current word: " + data);
                            $('#word').val(data);
                            hideSpinner();
                                                
                        })
                        .catch(function (error) { console.log("Error: Getting status"); })
                        .finally(function () { hideSpinner(); });                        
                    }
                    else {
                        // And the winner is...
                        $('#results').show();   
                        $('#btnReset').hide();   
                        $('#gameform').addClass('disabled');

                        if (data == "Computer") {
                            $('#winner').hide();
                            $('#loser').show();
                        }
                        else {
                            $('#winner').show();
                            $('#loser').hide();'
                        }                        
                    }
                },
                error => console.log("Error: Playing game"));
                        
        });
        
        $("#btnBegin").click(function (e) {            
            var name = $('#name').val();
            if (name === '') {
                $('#name').val("A human").trigger('change');;
            }

            // Try to create a new game
            var promise = createGame(name);
            promise.then(
                data => console.log("The game is created"),
                error => console.log("Error: Creating game"));

        });

        $(".btnReset").click(function (e) {

            // Try to reset the current game
            var promise = resetGame();
            promise.then(
                data => {
                    console.log("The game is reset");
                    $('#word').val("").trigger('change');
                    $('#results').hide();
                    $('#btnReset').show();
                    $('#gameform').removeClass('disabled');
                    hideSpinner();                                    
                },
                error => console.log("Error: Reseting game"));
        });

        function showSpinner() {
            $('#word').prop('readonly', true);
            $('#word').addClass('disabled')
            //Show spinner
            $('.spinner-border').show();
        }
        function hideSpinner() {
            $('#word').prop('readonly', false);
            $('#word').removeClass('disabled')
            //Hide spinner
            $('.spinner-border').hide();
            $('#word').focus();        
        }


    });


});