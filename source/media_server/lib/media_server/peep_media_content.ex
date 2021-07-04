defmodule MediaServer.PeepMediaContent do
  @moduledoc """
  The PeepMediaContent context.
  """

  import Ecto.Query, warn: false
  alias MediaServer.Repo

  alias MediaServer.PeepMediaContent.PeepMedia

  @doc """
  Returns the list of peep_media.

  ## Examples

      iex> list_peep_media()
      [%PeepMedia{}, ...]

  """
  def list_peep_media do
    Repo.all(PeepMedia)
  end

  @doc """
  Gets a single peep_media.

  Raises `Ecto.NoResultsError` if the Peep media does not exist.

  ## Examples

      iex> get_peep_media!(123)
      %PeepMedia{}

      iex> get_peep_media!(456)
      ** (Ecto.NoResultsError)

  """
  def get_peep_media!(id), do: Repo.get!(PeepMedia, id)

  @doc """
  Creates a peep_media.

  ## Examples

      iex> create_peep_media(%{field: value})
      {:ok, %PeepMedia{}}

      iex> create_peep_media(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_peep_media(attrs \\ %{}) do
    %PeepMedia{}
    |> PeepMedia.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a peep_media.

  ## Examples

      iex> update_peep_media(peep_media, %{field: new_value})
      {:ok, %PeepMedia{}}

      iex> update_peep_media(peep_media, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_peep_media(%PeepMedia{} = peep_media, attrs) do
    peep_media
    |> PeepMedia.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a peep_media.

  ## Examples

      iex> delete_peep_media(peep_media)
      {:ok, %PeepMedia{}}

      iex> delete_peep_media(peep_media)
      {:error, %Ecto.Changeset{}}

  """
  def delete_peep_media(%PeepMedia{} = peep_media) do
    Repo.delete(peep_media)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking peep_media changes.

  ## Examples

      iex> change_peep_media(peep_media)
      %Ecto.Changeset{data: %PeepMedia{}}

  """
  def change_peep_media(%PeepMedia{} = peep_media, attrs \\ %{}) do
    PeepMedia.changeset(peep_media, attrs)
  end
end
