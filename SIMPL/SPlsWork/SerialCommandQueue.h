namespace SerialCommandQueue;
        // class declarations
         class CommandQueue;
         class CommandArgs;
     class CommandQueue 
    {
        // class delegates

        // class events
        EventHandler CommandSent ( CommandQueue sender, CommandArgs e );

        // class functions
        FUNCTION AddCommand ( STRING command );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER TimerInterval;
    };

     class CommandArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Command[];
    };

