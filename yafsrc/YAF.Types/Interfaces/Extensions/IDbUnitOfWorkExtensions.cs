﻿/* Yet Another Forum.net
 * Copyright (C) 2006-2012 Jaben Cargman
 * http://www.yetanotherforum.net/
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 */
namespace YAF.Types.Interfaces.Extensions
{
    #region Using

    using System.Data;

    using YAF.Types.Interfaces.Data;

    #endregion

    /// <summary>
    ///     The db unit of work extensions.
    /// </summary>
    public static class IDbUnitOfWorkExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The commit.
        /// </summary>
        /// <param name="dbFunctionSession">
        /// The db function session.
        /// </param>
        public static void Commit([NotNull] this IDbFunctionSession dbFunctionSession)
        {
            CodeContracts.ArgumentNotNull(dbFunctionSession, "dbFunctionSession");

            if (dbFunctionSession.DbTransaction != null)
            {
                dbFunctionSession.DbTransaction.Commit();
            }
        }

        /// <summary>
        /// The rollback.
        /// </summary>
        /// <param name="dbFunctionSession">
        /// The db function session.
        /// </param>
        public static void Rollback([NotNull] this IDbFunctionSession dbFunctionSession)
        {
            CodeContracts.ArgumentNotNull(dbFunctionSession, "dbFunctionSession");

            if (dbFunctionSession.DbTransaction != null)
            {
                dbFunctionSession.DbTransaction.Rollback();
            }
        }

        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="command">
        /// The command. 
        /// </param>
        /// <param name="dbTransaction">
        /// The db transaction. 
        /// </param>
        public static void Populate([NotNull] this IDbCommand command, IDbTransaction dbTransaction)
        {
            CodeContracts.ArgumentNotNull(dbTransaction, "dbTransaction");
            CodeContracts.ArgumentNotNull(command, "command");

            command.Connection = dbTransaction.Connection;
            command.Transaction = dbTransaction;
        }

        #endregion
    }
}