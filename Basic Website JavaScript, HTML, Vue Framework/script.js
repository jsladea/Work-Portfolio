function Forecast(timestamp, temperature, high, low, sky, humidity, pressure, icon){
    this.time = vm.getHumanReadableDate(timestamp);
    this.temperature = temperature;
    this.high = high;
    this.low = low;
    this.sky = sky;
    this.humidity = humidity;
    this.pressure = pressure;
    this.icon = vm.getIconLink(icon);
}

const app = Vue.createApp({
    data() {
        return {
            error: false,
            fetchingLocation: false,
            fetchingWeather: false,
            location: {
            },

            currentConditions: {
                time:'',
                temperature: 0,
                high: 0,
                low: 0,
                sky:'',
                humidity:0,
                pressure: 0,
                icon:''
            },

            forecasts: [],
            neutralCount:40,
            likelyCount:0,
            unlikelyCount:0
        };
    },

    methods: {

        fetchData(){
            this.fetchingLocation = true;
            this.fetchingWeather = true;

            this.fetchLocation()
            .then( locationJson => {
                this.location = locationJson; //set location data
                this.fetchingLocation = false;
                this.fetchWeather();
            })
            .catch(error => {
                console.log("An error occurred while fetching data.")
                this.fetchingLocation = false;
                this.fetchingWeather = false;
                this.error = true;
            });
        },

        fetchLocation(){
            return fetch("https://api.freegeoip.app/json/?apikey=2bb94720-4fd9-11ec-9dd7-8f5634a9b075")
            .then(response => response.json());
        },

        fetchWeather(){
            console.log("Fetching weather");
            
            let units = "imperial";
            let appid = "24bed316bab905f5361040ddf743ba65";
            let url = `https://api.openweathermap.org/data/2.5/weather?lat=${this.location.latitude}&lon=${this.location.longitude}&units=${units}&appid=${appid}`;

            return fetch(url)
            .then(response => response.json())
            .then(json => {
                this.currentConditions = this.createForecast(json);
                this.fetchForecasts(units, appid);
                this.fetchingWeather = false;
            })
            .catch(error => {
                console.log("An error occurred while fetching weather data.");
                this.error = true;
            });
        },

        fetchForecasts(units, apiKey){
            let url = `https://api.openweathermap.org/data/2.5/forecast?lat=${this.location.latitude}&lon=${this.location.longitude}&units=${units}&cnt=40&appid=${apiKey}`;
            return fetch(url)
            .then(response => response.json())
            .then(json => {
                this.setForecasts(json.list)
            })
            .catch(error => {
                console.log("An error occurred while fetching forecast data.");
                this.error = true;
            });
        },

        createForecast(json){
            return new Forecast(json.dt, json.main.temp, json.main.temp_max,
             json.main.temp_min, json.weather[0].description, json.main.humidity,
              json.main.pressure, json.weather[0].icon);
        },

        setForecasts(forecasts){
            let forecastArray = [];
            for(index in forecasts){
                let f = forecasts[index];
                forecastArray[index] = this.createForecast(f);
            }
            this.forecasts = forecastArray;
        },

        getCoordinates(){
            if(this.location.hasOwnProperty('latitude') && this.location.hasOwnProperty('longitude')){
                return `at coordinates (${this.location.latitude}, ${this.location.longitude}).`;
            }
            return ' Unable to determine coordinates from the current Ip address.'; 
        },

        getIconLink(icon){
            return `http://openweathermap.org/img/wn/${icon}@2x.png`;
        },

        getHumanReadableDate(timestamp){
            let date = new Date(Number.parseInt(timestamp) * 1000);
            return date.toLocaleString();
        },

        forecastClicked(event){
            let classAttribute = event.currentTarget.getAttribute('class');
            if(classAttribute.includes("neutral")){
                event.currentTarget.setAttribute('class', 'forecast unlikely');
            }
            else if(classAttribute.includes("unlikely")){
                event.currentTarget.setAttribute('class', 'forecast likely');
            }
            else {
                event.currentTarget.setAttribute('class', 'forecast neutral');
            }

            this.updateLikelyhoodCounts();
            
        },

        updateLikelyhoodCounts(){
            this.neutralCount = document.querySelectorAll('.neutral').length -1;
            this.likelyCount = document.querySelectorAll('.likely').length -1;
            this.unlikelyCount = document.querySelectorAll('.unlikely').length -1;
        }

    },


    computed: {

        locationString() {
            let locationStr = '';
            if(this.location.hasOwnProperty('city')){
                locationStr += this.location.city + ", ";
            }
            if(this.location.hasOwnProperty('region_name')){
                locationStr += this.location.region_name + ", ";
            }
            if(this.location.hasOwnProperty('country_name')){
                locationStr += this.location.country_name;
            }

            if(locationStr !== ''){ //if there is a city, region, or country
                locationStr = 'in ' + locationStr;
            } 

            return `You are located ${locationStr} ${this.getCoordinates()}`;
        }

    }
});

const vm = app.mount("#app-root");
vm.fetchData();