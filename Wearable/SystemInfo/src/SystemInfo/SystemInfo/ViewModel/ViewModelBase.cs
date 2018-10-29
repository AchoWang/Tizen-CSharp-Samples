/*
 * Copyright 2018 Samsung Electronics Co., Ltd. All rights reserved.
 *
 * Licensed under the Flora License, Version 1.1 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://floralicense.org/license
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SystemInfo.ViewModel
{
    /// <summary>
    /// Base ViewModel class.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region fields

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        /// <summary>
        /// Generic set property method which also calls OnPropertyChanged() after value modification.
        /// </summary>
        /// <param name="storage">Value storage object</param>
        /// <param name="value">Value to set</param>
        /// <param name="propertyName">Automatically obtained property name</param>
        /// <typeparam name="T">Property value type</typeparam>
        /// <returns>True if value was changed, false if value isn't different from current.</returns>
        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Invokes PropertyChanged with automatically obtained property name.
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}