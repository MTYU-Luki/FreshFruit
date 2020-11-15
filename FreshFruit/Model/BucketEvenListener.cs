using System;
using System.Collections.Generic;
using System.Text;

namespace FreshFruit.Model
{
    interface BucketEvenListener
    {
        void onSucceed(string message);
        void onFailed(string message);
    }
}
