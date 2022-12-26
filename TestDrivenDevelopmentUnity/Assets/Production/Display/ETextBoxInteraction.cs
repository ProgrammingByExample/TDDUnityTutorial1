namespace Production.Display
{
    /// <summary>
    /// Describes how the text box closes or moves on from current state.
    /// </summary>
    public enum ETextBoxInteraction
    {
        /// <summary>
        /// The text box reacts to it's own events such as time.
        /// </summary>
        Automatic = 0,
        
        /// <summary>
        /// The text box reacts to player interaction.
        /// </summary>
        PlayerInteraction,
    }
}