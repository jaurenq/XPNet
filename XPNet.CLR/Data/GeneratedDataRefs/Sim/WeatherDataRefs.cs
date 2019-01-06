using System;
using System.Collections.Generic;
using System.Text;

namespace XPNet.Data
{
    public class sim_weatherDatarefs
    {
        private readonly IXPlaneData m_data;

        internal sim_weatherDatarefs(IXPlaneData data)
        {
            m_data = data;
        }

        /// <summary>
        ///  The type of clouds for this cloud layer.Currently there are only 3 cloud layers, 0, 1 or 2. Cloud types:<p>Clear = 0, High Cirrus = 1, Scattered = 2, Broken = 3, Overcast = 4, Stratus = 5 (740 and newer). Units:Cloud
        ///  Raw path: sim/weather/cloud_type[0]
        /// </summary>
        public IXPDataRef<int> cloud_type_0 { get { return m_data.GetInt("sim/weather/cloud_type[0]");} }

        /// <summary>
        ///  The type of clouds for this cloud layer.Currently there are only 3 cloud layers, 0, 1 or 2. Cloud types:<p>Clear = 0, High Cirrus = 1, Scattered = 2, Broken = 3, Overcast = 4, Stratus = 5 (740 and newer). Units:Cloud
        ///  Raw path: sim/weather/cloud_type[1]
        /// </summary>
        public IXPDataRef<int> cloud_type_1 { get { return m_data.GetInt("sim/weather/cloud_type[1]");} }

        /// <summary>
        ///  The type of clouds for this cloud layer.Currently there are only 3 cloud layers, 0, 1 or 2. Cloud types:<p>Clear = 0, High Cirrus = 1, Scattered = 2, Broken = 3, Overcast = 4, Stratus = 5 (740 and newer). Units:Cloud
        ///  Raw path: sim/weather/cloud_type[2]
        /// </summary>
        public IXPDataRef<int> cloud_type_2 { get { return m_data.GetInt("sim/weather/cloud_type[2]");} }

        /// <summary>
        ///  . Units:Coverage
        ///  Raw path: sim/weather/cloud_coverage[0]
        /// </summary>
        public IXPDataRef<float> cloud_coverage_0 { get { return m_data.GetFloat("sim/weather/cloud_coverage[0]");} }

        /// <summary>
        ///  . Units:Coverage
        ///  Raw path: sim/weather/cloud_coverage[1]
        /// </summary>
        public IXPDataRef<float> cloud_coverage_1 { get { return m_data.GetFloat("sim/weather/cloud_coverage[1]");} }

        /// <summary>
        ///  . Units:Coverage
        ///  Raw path: sim/weather/cloud_coverage[2]
        /// </summary>
        public IXPDataRef<float> cloud_coverage_2 { get { return m_data.GetFloat("sim/weather/cloud_coverage[2]");} }

        /// <summary>
        ///  The base altitude for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_base_msl_m[0]
        /// </summary>
        public IXPDataRef<float> cloud_base_msl_m_0 { get { return m_data.GetFloat("sim/weather/cloud_base_msl_m[0]");} }

        /// <summary>
        ///  The base altitude for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_base_msl_m[1]
        /// </summary>
        public IXPDataRef<float> cloud_base_msl_m_1 { get { return m_data.GetFloat("sim/weather/cloud_base_msl_m[1]");} }

        /// <summary>
        ///  The base altitude for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_base_msl_m[2]
        /// </summary>
        public IXPDataRef<float> cloud_base_msl_m_2 { get { return m_data.GetFloat("sim/weather/cloud_base_msl_m[2]");} }

        /// <summary>
        ///  The tops for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_tops_msl_m[0]
        /// </summary>
        public IXPDataRef<float> cloud_tops_msl_m_0 { get { return m_data.GetFloat("sim/weather/cloud_tops_msl_m[0]");} }

        /// <summary>
        ///  The tops for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_tops_msl_m[1]
        /// </summary>
        public IXPDataRef<float> cloud_tops_msl_m_1 { get { return m_data.GetFloat("sim/weather/cloud_tops_msl_m[1]");} }

        /// <summary>
        ///  The tops for this cloud layer.. Units:meters
        ///  Raw path: sim/weather/cloud_tops_msl_m[2]
        /// </summary>
        public IXPDataRef<float> cloud_tops_msl_m_2 { get { return m_data.GetFloat("sim/weather/cloud_tops_msl_m[2]");} }

        /// <summary>
        ///  The reported visibility (e.g. what the METAR/weather window says).. Units:meters
        ///  Raw path: sim/weather/visibility_reported_m
        /// </summary>
        public IXPDataRef<float> visibility_reported_m { get { return m_data.GetFloat("sim/weather/visibility_reported_m");} }

        /// <summary>
        ///  The percentage of rain falling.. Units:[0.0 - 1.0]
        ///  Raw path: sim/weather/rain_percent
        /// </summary>
        public IXPDataRef<float> rain_percent { get { return m_data.GetFloat("sim/weather/rain_percent");} }

        /// <summary>
        ///  The percentage of thunderstorms present.. Units:[0.0 - 1.0]
        ///  Raw path: sim/weather/thunderstorm_percent
        /// </summary>
        public IXPDataRef<float> thunderstorm_percent { get { return m_data.GetFloat("sim/weather/thunderstorm_percent");} }

        /// <summary>
        ///  The percentage of wind turbulence present.. Units:[0.0 - 1.0]
        ///  Raw path: sim/weather/wind_turbulence_percent
        /// </summary>
        public IXPDataRef<float> wind_turbulence_percent { get { return m_data.GetFloat("sim/weather/wind_turbulence_percent");} }

        /// <summary>
        ///  The barometric pressure at sea level.. Units:29.92
        ///  Raw path: sim/weather/barometer_sealevel_inhg
        /// </summary>
        public IXPDataRef<float> barometer_sealevel_inhg { get { return m_data.GetFloat("sim/weather/barometer_sealevel_inhg");} }

        /// <summary>
        ///  Whether a real weather file has been located.. Units:0,1
        ///  Raw path: sim/weather/has_real_weather_bool
        /// </summary>
        public IXPDataRef<int> has_real_weather_bool { get { return m_data.GetInt("sim/weather/has_real_weather_bool");} }

        /// <summary>
        ///  Whether a real weather file is in use.. Units:0,1
        ///  Raw path: sim/weather/use_real_weather_bool
        /// </summary>
        public IXPDataRef<int> use_real_weather_bool { get { return m_data.GetInt("sim/weather/use_real_weather_bool");} }

        /// <summary>
        ///  If true, the sim will attempt to download real weather files when real weather is enabled.. Units:0,1
        ///  Raw path: sim/weather/download_real_weather
        /// </summary>
        public IXPDataRef<int> download_real_weather { get { return m_data.GetInt("sim/weather/download_real_weather");} }

        /// <summary>
        ///  This is the barometric pressure at the point the current flight is at.. Units:29.92+-....
        ///  Raw path: sim/weather/barometer_current_inhg
        /// </summary>
        public IXPDataRef<float> barometer_current_inhg { get { return m_data.GetFloat("sim/weather/barometer_current_inhg");} }

        /// <summary>
        ///  This is the acceleration of gravity for the current planet.. Units:meters/sec^2
        ///  Raw path: sim/weather/gravity_mss
        /// </summary>
        public IXPDataRef<float> gravity_mss { get { return m_data.GetFloat("sim/weather/gravity_mss");} }

        /// <summary>
        ///  This is the speed of sound in meters/second at the plane's location.. Units:meters/sec
        ///  Raw path: sim/weather/speed_sound_ms
        /// </summary>
        public IXPDataRef<float> speed_sound_ms { get { return m_data.GetFloat("sim/weather/speed_sound_ms");} }

        /// <summary>
        ///  The center altitude of this layer of wind in MSL meters.. Units:meters
        ///  Raw path: sim/weather/wind_altitude_msl_m[0]
        /// </summary>
        public IXPDataRef<float> wind_altitude_msl_m_0 { get { return m_data.GetFloat("sim/weather/wind_altitude_msl_m[0]");} }

        /// <summary>
        ///  The center altitude of this layer of wind in MSL meters.. Units:meters
        ///  Raw path: sim/weather/wind_altitude_msl_m[1]
        /// </summary>
        public IXPDataRef<float> wind_altitude_msl_m_1 { get { return m_data.GetFloat("sim/weather/wind_altitude_msl_m[1]");} }

        /// <summary>
        ///  The center altitude of this layer of wind in MSL meters.. Units:meters
        ///  Raw path: sim/weather/wind_altitude_msl_m[2]
        /// </summary>
        public IXPDataRef<float> wind_altitude_msl_m_2 { get { return m_data.GetFloat("sim/weather/wind_altitude_msl_m[2]");} }

        /// <summary>
        ///  The direction the wind is blowing from in degrees from true north c lockwise.. Units:[0 - 360)
        ///  Raw path: sim/weather/wind_direction_degt[0]
        /// </summary>
        public IXPDataRef<float> wind_direction_degt_0 { get { return m_data.GetFloat("sim/weather/wind_direction_degt[0]");} }

        /// <summary>
        ///  The direction the wind is blowing from in degrees from true north c lockwise.. Units:[0 - 360)
        ///  Raw path: sim/weather/wind_direction_degt[1]
        /// </summary>
        public IXPDataRef<float> wind_direction_degt_1 { get { return m_data.GetFloat("sim/weather/wind_direction_degt[1]");} }

        /// <summary>
        ///  The direction the wind is blowing from in degrees from true north c lockwise.. Units:[0 - 360)
        ///  Raw path: sim/weather/wind_direction_degt[2]
        /// </summary>
        public IXPDataRef<float> wind_direction_degt_2 { get { return m_data.GetFloat("sim/weather/wind_direction_degt[2]");} }

        /// <summary>
        ///  The wind speed in knots.. Units:kts
        ///  Raw path: sim/weather/wind_speed_kt[0]
        /// </summary>
        public IXPDataRef<float> wind_speed_kt_0 { get { return m_data.GetFloat("sim/weather/wind_speed_kt[0]");} }

        /// <summary>
        ///  The wind speed in knots.. Units:kts
        ///  Raw path: sim/weather/wind_speed_kt[1]
        /// </summary>
        public IXPDataRef<float> wind_speed_kt_1 { get { return m_data.GetFloat("sim/weather/wind_speed_kt[1]");} }

        /// <summary>
        ///  The wind speed in knots.. Units:kts
        ///  Raw path: sim/weather/wind_speed_kt[2]
        /// </summary>
        public IXPDataRef<float> wind_speed_kt_2 { get { return m_data.GetFloat("sim/weather/wind_speed_kt[2]");} }

        /// <summary>
        ///  The direction for a wind shear, per above.. Units:[0 - 360)
        ///  Raw path: sim/weather/shear_direction_degt[0]
        /// </summary>
        public IXPDataRef<float> shear_direction_degt_0 { get { return m_data.GetFloat("sim/weather/shear_direction_degt[0]");} }

        /// <summary>
        ///  The direction for a wind shear, per above.. Units:[0 - 360)
        ///  Raw path: sim/weather/shear_direction_degt[1]
        /// </summary>
        public IXPDataRef<float> shear_direction_degt_1 { get { return m_data.GetFloat("sim/weather/shear_direction_degt[1]");} }

        /// <summary>
        ///  The direction for a wind shear, per above.. Units:[0 - 360)
        ///  Raw path: sim/weather/shear_direction_degt[2]
        /// </summary>
        public IXPDataRef<float> shear_direction_degt_2 { get { return m_data.GetFloat("sim/weather/shear_direction_degt[2]");} }

        /// <summary>
        ///  The gain from the shear in knots.. Units:kts
        ///  Raw path: sim/weather/shear_speed_kt[0]
        /// </summary>
        public IXPDataRef<float> shear_speed_kt_0 { get { return m_data.GetFloat("sim/weather/shear_speed_kt[0]");} }

        /// <summary>
        ///  The gain from the shear in knots.. Units:kts
        ///  Raw path: sim/weather/shear_speed_kt[1]
        /// </summary>
        public IXPDataRef<float> shear_speed_kt_1 { get { return m_data.GetFloat("sim/weather/shear_speed_kt[1]");} }

        /// <summary>
        ///  The gain from the shear in knots.. Units:kts
        ///  Raw path: sim/weather/shear_speed_kt[2]
        /// </summary>
        public IXPDataRef<float> shear_speed_kt_2 { get { return m_data.GetFloat("sim/weather/shear_speed_kt[2]");} }

        /// <summary>
        ///  A turbulence factor, 0-10, the unit is just a scale.. Units:[0 - 10]
        ///  Raw path: sim/weather/turbulence[0]
        /// </summary>
        public IXPDataRef<float> turbulence_0 { get { return m_data.GetFloat("sim/weather/turbulence[0]");} }

        /// <summary>
        ///  A turbulence factor, 0-10, the unit is just a scale.. Units:[0 - 10]
        ///  Raw path: sim/weather/turbulence[1]
        /// </summary>
        public IXPDataRef<float> turbulence_1 { get { return m_data.GetFloat("sim/weather/turbulence[1]");} }

        /// <summary>
        ///  A turbulence factor, 0-10, the unit is just a scale.. Units:[0 - 10]
        ///  Raw path: sim/weather/turbulence[2]
        /// </summary>
        public IXPDataRef<float> turbulence_2 { get { return m_data.GetFloat("sim/weather/turbulence[2]");} }

        /// <summary>
        ///  Amplitude of waves in the water (height of waves). Units:meters
        ///  Raw path: sim/weather/wave_amplitude
        /// </summary>
        public IXPDataRef<float> wave_amplitude { get { return m_data.GetFloat("sim/weather/wave_amplitude");} }

        /// <summary>
        ///  Length of a single wave in the water. Units:meters
        ///  Raw path: sim/weather/wave_length
        /// </summary>
        public IXPDataRef<float> wave_length { get { return m_data.GetFloat("sim/weather/wave_length");} }

        /// <summary>
        ///  Speed of water waves. Units:meters/second
        ///  Raw path: sim/weather/wave_speed
        /// </summary>
        public IXPDataRef<float> wave_speed { get { return m_data.GetFloat("sim/weather/wave_speed");} }

        /// <summary>
        ///  Direction of waves.. Units:degrees
        ///  Raw path: sim/weather/wave_dir
        /// </summary>
        public IXPDataRef<int> wave_dir { get { return m_data.GetInt("sim/weather/wave_dir");} }

        /// <summary>
        ///  The temperature at sea level.. Units:degreesC
        ///  Raw path: sim/weather/temperature_sealevel_c
        /// </summary>
        public IXPDataRef<float> temperature_sealevel_c { get { return m_data.GetFloat("sim/weather/temperature_sealevel_c");} }

        /// <summary>
        ///  The dew point at sea level.. Units:degrees
        ///  Raw path: sim/weather/dewpoi_sealevel_c
        /// </summary>
        public IXPDataRef<float> dewpoi_sealevel_c { get { return m_data.GetFloat("sim/weather/dewpoi_sealevel_c");} }

        /// <summary>
        ///  The air temperature outside the aircraft (at altitude).. Units:degrees
        ///  Raw path: sim/weather/temperature_ambient_c
        /// </summary>
        public IXPDataRef<float> temperature_ambient_c { get { return m_data.GetFloat("sim/weather/temperature_ambient_c");} }

        /// <summary>
        ///  The air temperature at the leading edge of the wings in degrees C.. Units:degrees
        ///  Raw path: sim/weather/temperature_le_c
        /// </summary>
        public IXPDataRef<float> temperature_le_c { get { return m_data.GetFloat("sim/weather/temperature_le_c");} }

        /// <summary>
        ///  The percentage of thermal occurance in the area.. Units:[0.0 - 1.0]
        ///  Raw path: sim/weather/thermal_percent
        /// </summary>
        public IXPDataRef<float> thermal_percent { get { return m_data.GetFloat("sim/weather/thermal_percent");} }

        /// <summary>
        ///  The climb rate for thermals.. Units:m/s
        ///  Raw path: sim/weather/thermal_rate_ms
        /// </summary>
        public IXPDataRef<float> thermal_rate_ms { get { return m_data.GetFloat("sim/weather/thermal_rate_ms");} }

        /// <summary>
        ///  The top of thermals in meters MSL.. Units:m
        ///  Raw path: sim/weather/thermal_altitude_msl_m
        /// </summary>
        public IXPDataRef<float> thermal_altitude_msl_m { get { return m_data.GetFloat("sim/weather/thermal_altitude_msl_m");} }

        /// <summary>
        ///  The friction constant for runways (how wet they are).  0 = good, 1 = fair, 2 = poor. Units:0,1,2
        ///  Raw path: sim/weather/runway_friction
        /// </summary>
        public IXPDataRef<float> runway_friction { get { return m_data.GetFloat("sim/weather/runway_friction");} }

        /// <summary>
        ///  0 = uniform conditions, 1 = patchy conditions. Units:Booelan
        ///  Raw path: sim/weather/runway_is_patchy
        /// </summary>
        public IXPDataRef<float> runway_is_patchy { get { return m_data.GetFloat("sim/weather/runway_is_patchy");} }

        /// <summary>
        ///  The effective direction of the wind at the plane's location.. Units:[0-359)
        ///  Raw path: sim/weather/wind_direction_degt
        /// </summary>
        public IXPDataRef<float> wind_direction_degt { get { return m_data.GetFloat("sim/weather/wind_direction_degt");} }

        /// <summary>
        ///  The effective speed of the wind at the plane's location.. Units:kts
        ///  Raw path: sim/weather/wind_speed_kt
        /// </summary>
        public IXPDataRef<float> wind_speed_kt { get { return m_data.GetFloat("sim/weather/wind_speed_kt");} }

        /// <summary>
        ///  Wind direction vector in OpenGL coordinates, X component.. Units:meters/sec
        ///  Raw path: sim/weather/wind_now_x_msc
        /// </summary>
        public IXPDataRef<float> wind_now_x_msc { get { return m_data.GetFloat("sim/weather/wind_now_x_msc");} }

        /// <summary>
        ///  Wind direction vector in OpenGL coordinates, Y component.. Units:meters/sec
        ///  Raw path: sim/weather/wind_now_y_msc
        /// </summary>
        public IXPDataRef<float> wind_now_y_msc { get { return m_data.GetFloat("sim/weather/wind_now_y_msc");} }

        /// <summary>
        ///  Wind direction vector in OpenGL coordinates, Z component.. Units:meters/sec
        ///  Raw path: sim/weather/wind_now_z_msc
        /// </summary>
        public IXPDataRef<float> wind_now_z_msc { get { return m_data.GetFloat("sim/weather/wind_now_z_msc");} }

        /// <summary>
        ///  The amount of rain on the airplane windshield as a ratio from 0 to 1.. Units:[0..1]
        ///  Raw path: sim/weather/precipitation_on_aircraft_ratio
        /// </summary>
        public IXPDataRef<float> precipitation_on_aircraft_ratio { get { return m_data.GetFloat("sim/weather/precipitation_on_aircraft_ratio");} }
    }
}