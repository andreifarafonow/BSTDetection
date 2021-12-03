using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public static class CamObserver
    {
        static AppDbContext _appDbContext = new AppDbContext();
        static Random _random = new Random();

        static bool _isStarted = false;
        static string _camsFolder = @"D:\kazan_cam2";

        public static void Start()
        {
            if (_isStarted == false)
            {
                new Thread(() =>
                {

                    int[] dirs = Directory.GetDirectories(_camsFolder).Select(x => int.Parse((new DirectoryInfo(x)).Name)).OrderBy(x => x).ToArray();
                    while (true)
                    {
                        foreach (int camId in dirs)
                        {
                            string imgFolder = GetActualCamImagePath(_camsFolder, camId);

                            Cam currentCam = _appDbContext.Cams.First(x => x.Id == camId);

                            currentCam.ImgLink = Path.Combine("kazan_cam2", imgFolder).Replace('\\', '/');

                            // TODO: CV
                            double isFull = _random.Next(100) < 10 ? 1 : 0;

                            if(currentCam.IsFull == 0 && isFull != 0)
                            {
                                _appDbContext.Tasks.Add(new Task() { CamId = currentCam.Id, IsComplete = false, StartDate = DateTime.Now });
                            }
                            

                            currentCam.IsFull = isFull;

                            if (currentCam.IsFull == 0)
                            {
                                currentCam.InWork = false;
                            }

                            _appDbContext.SaveChanges();

                            Thread.Sleep(1000);
                        }
                    }

                }).Start();

                _isStarted = true;
            }
        }

        private static string GetActualCamImagePath(string camsFolder, int camId)
        {
            string[] allfiles = Directory.GetFiles(Path.Combine(camsFolder, camId.ToString()));

            TimeSpan minSpan = TimeSpan.FromDays(365);
            string actualPath = "";

            foreach (string filename in allfiles)
            {
                string timeStr = Path.GetFileNameWithoutExtension(filename).Substring(11).Replace('-', ':').Replace('_', ' ');

                var dateTime = DateTime.Parse(timeStr);

                TimeSpan span = (DateTime.Now - dateTime).Duration();

                if (span < minSpan)
                {
                    minSpan = span;
                    actualPath = Path.Combine(camId.ToString(), Path.GetFileName(filename));
                }
            }

            return actualPath;
        }



    }
}