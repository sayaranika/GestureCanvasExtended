public struct configuartion_parameters_t
{
    public int fps;
    public double sliding_window_s;
    public int sliding_window_frame_cnt;
    public int update_interval;
    public int repeat_cnt;

    public configuartion_parameters_t(int i)
    {
        fps = 30;
        sliding_window_s = 2.0;
        update_interval = 5;
        repeat_cnt = 3;

        sliding_window_frame_cnt = (int)((double)fps * sliding_window_s);
    }
};