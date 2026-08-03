using System;

/*
 * ===================================================================
 * ETERNAL QUEST PROGRAM
 * ===================================================================
 *
 * WAYS THIS PROGRAM EXCEEDS THE CORE REQUIREMENTS:
 *
 * 1. Two extra goal types were added beyond the required Simple,
 *    Eternal, and Checklist goals:
 *
 *      - ProgressGoal: lets the user build toward one large goal
 *        over time (e.g. running a marathon one mile at a time).
 *        It tracks a unit-based progress bar (e.g. "14/26 miles,
 *        54%") and awards a large one-time completion bonus once
 *        the target amount is reached.
 *
 *      - NegativeGoal: represents a bad habit the user is trying to
 *        stop. Recording this goal SUBTRACTS points instead of
 *        adding them, reinforcing that breaking bad habits matters
 *        just as much as building good ones.
 *
 * 2. A simple leveling system was layered on top of the raw point
 *    total (see GoalManager.DisplayPlayerInfo). Every 1000 points
 *    earns the user a new "Level," and level milestones unlock a
 *    themed title (Humble Beginner -> Faithful Disciple ->
 *    Terrestrial Trailblazer -> Celestial Champion), so progress
 *    feels like a game rather than a plain checklist.
 *
 * 3. Encouraging, contextual feedback was added for every recorded
 *    event -- a congratulations message with the exact points
 *    earned, a "you lost points" message for negative goals, and a
 *    special "*** Goal complete! ***" celebration the moment a goal
 *    is finished.
 *
 * 4. Save/Load was implemented generically so that ALL five goal
 *    types (including the two custom ones above) can be serialized
 *    to a plain text file and reloaded without losing any progress.
 *    This uses a simple "Type:field,field,field" text format and a
 *    small factory-style parser in GoalManager.LoadGoals(), similar
 *    to the pattern described in the assignment instructions.
 *
 * ===================================================================
 */

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
