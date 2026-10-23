namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct AVDynamicHDRPlus
    {
        public byte itu_t_t35_country_code;

        public byte application_version;

        public byte num_windows;

        public AVHDRPlusColorTransformParams3 @params;

        public AVRational targeted_system_display_maximum_luminance;

        public byte targeted_system_display_actual_peak_luminance_flag;

        public byte num_rows_targeted_system_display_actual_peak_luminance;

        public byte num_cols_targeted_system_display_actual_peak_luminance;

        public AVRational25x25 targeted_system_display_actual_peak_luminance;

        public byte mastering_display_actual_peak_luminance_flag;

        public byte num_rows_mastering_display_actual_peak_luminance;

        public byte num_cols_mastering_display_actual_peak_luminance;

        public AVRational25x25 mastering_display_actual_peak_luminance;
    }
}
