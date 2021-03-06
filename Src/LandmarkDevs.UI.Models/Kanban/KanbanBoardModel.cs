﻿using System.Collections.ObjectModel;

namespace LandmarkDevs.UI.Models.Kanban
{
    /// <summary>
    ///     Class KanbanBoardModel.
    /// </summary>
    public class KanbanBoardModel
    {
        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the kanban items.
        /// </summary>
        /// <value>The kanban items.</value>
        public ObservableCollection<KanbanItemModel> KanbanItems { get; set; }
    }
}