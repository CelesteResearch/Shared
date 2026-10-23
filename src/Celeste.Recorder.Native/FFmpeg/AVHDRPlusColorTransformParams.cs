namespace FFmpeg
{
    public struct AVHDRPlusColorTransformParams
    {
        public AVRational window_upper_left_corner_x;

        public AVRational window_upper_left_corner_y;

        public AVRational window_lower_right_corner_x;

        public AVRational window_lower_right_corner_y;

        public ushort center_of_ellipse_x;

        public ushort center_of_ellipse_y;

        public byte rotation_angle;

        public ushort semimajor_axis_internal_ellipse;

        public ushort semimajor_axis_external_ellipse;

        public ushort semiminor_axis_external_ellipse;

        public AVHDRPlusOverlapProcessOption overlap_process_option;

        public AVRational3 maxscl;

        public AVRational average_maxrgb;

        public byte num_distribution_maxrgb_percentiles;

        public AVHDRPlusPercentile15 distribution_maxrgb;

        public AVRational fraction_bright_pixels;

        public byte tone_mapping_flag;

        public AVRational knee_point_x;

        public AVRational knee_point_y;

        public byte num_bezier_curve_anchors;

        public AVRational15 bezier_curve_anchors;

        public byte color_saturation_mapping_flag;

        public AVRational color_saturation_weight;
    }
}
