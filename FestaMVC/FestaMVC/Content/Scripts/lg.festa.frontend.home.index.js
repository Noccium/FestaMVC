var lg = {festa:{frontend:{home:{}}}}

lg.festa.frontend.home.index = function($el) {
    this.$el = $el
    
    this.init()
}


lg.festa.frontend.home.index.prototype= {
    init: function() {
        this.$elLogo =  this.$el[0].parentElement.querySelector('div')

        this.ligaEventos()
    },
    ligaEventos: function() {
        this.$elLogo.addEventListener("click", function() {
            window.location.replace("../login/index.html");
            console.log("teste");
            
        })
    }
}