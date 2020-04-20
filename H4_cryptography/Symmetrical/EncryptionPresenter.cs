using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace H4_cryptography.Symmetrical
{
    class EncryptionPresenter
    {
        private static EncryptionPresenter presenter;
        private EncryptionAlgorithmController controller;
        private EncryptionView view;
        private Stopwatch watch;
        private byte[] empty;
        public EncryptionPresenter()
        {
            controller = new EncryptionAlgorithmController();
            view = new EncryptionView();
            empty = new byte[1];
        }
        public static void Start()
        {
            presenter = new EncryptionPresenter();
            presenter.Run();
        }
        private void Run()
        {
            int choice = -1;
            while (choice != 0)
            {
                choice = view.ChooseAction(Convert.ToBase64String(controller.Key ?? empty), Convert.ToBase64String(controller.Iv ?? empty), controller.algoname);
                switch (choice)
                {
                    case 1:
                        string e = view.Encrypt();
                        watch = Stopwatch.StartNew();
                        string eresult = controller.Encrypt(e);
                        view.EncryptResult(eresult, watch.ElapsedMilliseconds);
                        watch.Stop();
                        break;
                    case 2:
                        string d = view.Decrypt();
                        watch = Stopwatch.StartNew();
                        string dresult = controller.Decrypt(d);
                        view.DecryptResult(dresult, watch.ElapsedMilliseconds);
                        watch.Stop();
                        break;
                    case 3:
                        controller.SetKey(view.SetKey());
                        break;
                    case 4:
                        controller.SetIV(view.SetIV());
                        break;
                    case 5:
                        ChooseAlgorithm();
                        break;
                    default:
                        break;
                }

            }
        }
        private void ChooseAlgorithm()
        {
            controller.ChooseAlgorithm(view.ChooseAlgorithm());
        }

    }
}
